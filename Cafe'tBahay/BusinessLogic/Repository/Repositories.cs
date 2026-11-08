using Model;
using System.Data;

namespace BusinessLogic.Repository
{
    internal sealed class UserRepository : RepositoryBase
    {
        internal UserRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal UserAccount Login(
            string username,
            string password)
        {
            Session.Logout();

            using (var connection = Db.Open())
            using (var transaction = connection.BeginTransaction(
                IsolationLevel.Serializable))
            {
                DataTable table = Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        UserID AS Id,
                        Username,
                        [Password],
                        Role,
                        IsLocked,
                        FailedAttempts
                      FROM dbo.tblUser WITH (UPDLOCK, HOLDLOCK)
                      WHERE Username = @username",
                    "@username", username);

                if (table.Rows.Count == 0)
                {
                    transaction.Commit();
                    throw new UnauthorizedAccessException(
                        "Username does not exist.");
                }

                DataRow row = table.Rows[0];
                int id = Convert.ToInt32(row["Id"]);

                if (Convert.ToBoolean(row["IsLocked"]))
                {
                    transaction.Commit();
                    throw new UnauthorizedAccessException(
                        "Account locked. Contact an Admin.");
                }

                string role = Convert.ToString(row["Role"]);

                if (role != "Admin" && role != "Cashier")
                {
                    transaction.Commit();
                    throw new UnauthorizedAccessException(
                        "Invalid saved role.");
                }

                
                string storedPassword = row.IsNull("Password") ? string.Empty : Convert.ToString(row["Password"]);
                bool validPassword = (password == storedPassword);

                if (!validPassword)
                {
                    int attempts = Convert.ToInt32(row["FailedAttempts"]) + 1;
                    bool locked = attempts >= 3;

                    Database.Execute(
                        connection,
                        transaction,
                        @"UPDATE dbo.tblUser
                          SET FailedAttempts = @attempts,
                              IsLocked = @locked
                          WHERE UserID = @id",
                        "@attempts", attempts,
                        "@locked", locked,
                        "@id", id);

                    transaction.Commit();

                    throw new UnauthorizedAccessException(
                        locked
                            ? "Account locked after three incorrect passwords."
                            : "Incorrect password.");
                }

                Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblUser
                      SET FailedAttempts = 0
                      WHERE UserID = @id",
                    "@id", id);

                transaction.Commit();

                Session.UserId = id;

                return new UserAccount
                {
                    Id = id,
                    Username = Convert.ToString(row["Username"]),
                    Role = role,
                    FailedAttempts = 0,
                    IsLocked = false
                };
            }
        }

        internal DataTable GetAll()
        {
            return Run(true, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        UserID AS Id,
                        Username,
                        Role,
                        IsLocked,
                        FailedAttempts
                      FROM dbo.tblUser
                      ORDER BY Username"));
        }

        internal int Create(
             string username,
             string password,
             string role)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblUser
                        (Username, [Password], Role)
                      OUTPUT INSERTED.UserID
                      VALUES (@username, @password, @role)",
                    "@username", username,
                    "@password", password,
                    "@role", role)));
        }

        internal void ChangeRole(int id, string role)
        {
            Run(true, (connection, transaction) =>
            {
                if (Session.UserId == id)
                    throw new InvalidOperationException(
                        "Use another Admin account to change this account.");

                DataTable users = Database.Table(
                    connection,
                    transaction,
                    @"SELECT UserID AS Id, Role
                      FROM dbo.tblUser WITH (UPDLOCK, HOLDLOCK)");

                DataRow[] target =
                    users.Select("Id = " + id);

                if (target.Length != 1)
                    throw new InvalidOperationException(
                        "User not found.");

                bool isAdmin =
                    Convert.ToString(target[0]["Role"])
                    == "Admin";

                if (isAdmin &&
                    role != "Admin" &&
                    users.Select("Role = 'Admin'").Length <= 1)
                {
                    throw new InvalidOperationException(
                        "The last Admin cannot be downgraded.");
                }

                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblUser
                      SET Role = @role
                      WHERE UserID = @id",
                    "@role", role,
                    "@id", id));

                return 0;
            });
        }

        internal void Delete(int id)
        {
            Run(true, (connection, transaction) =>
            {
                if (Session.UserId == id)
                    throw new InvalidOperationException(
                        "You cannot delete your signed-in account.");

                DataTable users = Database.Table(
                    connection,
                    transaction,
                    @"SELECT UserID AS Id, Role
                      FROM dbo.tblUser WITH (UPDLOCK, HOLDLOCK)");

                DataRow[] target =
                    users.Select("Id = " + id);

                if (target.Length != 1)
                    throw new InvalidOperationException(
                        "User not found.");

                bool isAdmin =
                    Convert.ToString(target[0]["Role"])
                    == "Admin";

                if (isAdmin &&
                    users.Select("Role = 'Admin'").Length <= 1)
                {
                    throw new InvalidOperationException(
                        "The last Admin cannot be deleted.");
                }

                if (users.Rows.Count <= 2)
                    throw new InvalidOperationException(
                        "At least two accounts must remain.");

                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"DELETE FROM dbo.tblUser
                      WHERE UserID = @id",
                    "@id", id));

                return 0;
            });
        }

        internal void ResetPassword(
            int id,
            string plainPassword)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblUser
                      SET [Password] = @password,
                          FailedAttempts = 0,
                          IsLocked = 0
                      WHERE UserID = @id",
                    "@password", plainPassword,
                    "@id", id));

                return 0;
            });
        }

        internal void Bootstrap(
            string adminUsername,
            string adminPassword,
            string cashierUsername,
            string cashierPassword)
        {
            using (var connection = Db.Open())
            using (var transaction = connection.BeginTransaction(
                IsolationLevel.Serializable))
            {
                DataTable users = Database.Table(
                    connection,
                    transaction,
                    @"SELECT UserID, Username, [Password]
                      FROM dbo.tblUser WITH (UPDLOCK, HOLDLOCK)");

                foreach (DataRow row in users.Rows)
                {
                    if (!row.IsNull("Password"))
                        throw new InvalidOperationException(
                            "Initial setup is already closed. Log in as an Admin to reset passwords.");
                }

                const string sql = @"
                    IF EXISTS
                    (
                        SELECT 1
                        FROM dbo.tblUser
                        WHERE Username = @username
                    )
                    BEGIN
                        UPDATE dbo.tblUser
                        SET [Password] = @password,
                            Role = @role,
                            FailedAttempts = 0,
                            IsLocked = 0
                        WHERE Username = @username;
                    END
                    ELSE
                    BEGIN
                        INSERT INTO dbo.tblUser
                            (Username, [Password], Role)
                        VALUES (@username, @password, @role);
                    END;";

                Database.Execute(
                    connection,
                    transaction,
                    sql,
                    "@username", adminUsername,
                    "@password", adminPassword,
                    "@role", "Admin");

                Database.Execute(
                    connection,
                    transaction,
                    sql,
                    "@username", cashierUsername,
                    "@password", cashierPassword,
                    "@role", "Cashier");

                transaction.Commit();
            }
        }
    }

    internal sealed class SupplierRepository : RepositoryBase
    {
        internal SupplierRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal DataTable GetAll()
        {
            return Run(true, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        [SupplierID] AS Id,
                        [SupplierName] AS SupplierName,
                        [ProductSupplied] AS ProductsSupplied,
                        [ContactPerson] AS ContactPerson,
                        [ContactNumber] AS ContactNumber,
                        [EmailAddress] AS Email,
                        [Address] AS Address,
                        [Status] AS Status,
                        [Notes/Remarks(Optional)] AS Notes
                      FROM dbo.tblSupplierTable
                      ORDER BY [SupplierName]"));
        }

        internal int Add(Supplier supplier)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblSupplierTable
                        ([SupplierName], [ProductSupplied],
                         [ContactPerson], [ContactNumber],
                         [EmailAddress], [Address],
                         [Status], [Notes/Remarks(Optional)])
                      OUTPUT INSERTED.[SupplierID]
                      VALUES
                        (@name, @products, @person, @phone,
                         @email, @address, @status, @notes)",
                    "@name", supplier.SupplierName,
                    "@products", supplier.ProductsSupplied,
                    "@person", supplier.ContactPerson,
                    "@phone", supplier.ContactNumber,
                    "@email", supplier.Email,
                    "@address", supplier.Address,
                    "@status", supplier.Status,
                    "@notes", supplier.Notes)));
        }

        internal void Update(Supplier supplier)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblSupplierTable
                      SET [SupplierName] = @name,
                          [ProductSupplied] = @products,
                          [ContactPerson] = @person,
                          [ContactNumber] = @phone,
                          [EmailAddress] = @email,
                          [Address] = @address,
                          [Status] = @status,
                          [Notes/Remarks(Optional)] = @notes
                      WHERE [SupplierID] = @id",
                    "@name", supplier.SupplierName,
                    "@products", supplier.ProductsSupplied,
                    "@person", supplier.ContactPerson,
                    "@phone", supplier.ContactNumber,
                    "@email", supplier.Email,
                    "@address", supplier.Address,
                    "@status", supplier.Status,
                    "@notes", supplier.Notes,
                    "@id", supplier.Id));

                return 0;
            });
        }

        internal void Deactivate(int id)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblSupplierTable
                      SET [Status] = 'Inactive'
                      WHERE [SupplierID] = @id",
                    "@id", id));

                return 0;
            });
        }

        internal void Delete(int id)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"DELETE FROM dbo.tblSupplierTable
                      WHERE [SupplierID] = @id",
                    "@id", id));

                return 0;
            });
        }
    }

    internal sealed class CategoryRepository : RepositoryBase
    {
        internal CategoryRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal DataTable GetAll()
        {
            return Run(true, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        [CategoryID] AS Id,
                        [CategoryName] AS Name,
                        [Description] AS Description,
                        [Notes/Remarks(Optional)] AS Notes
                      FROM dbo.tblCategory
                      ORDER BY [CategoryName]"));
        }

        internal DataTable Lookup()
        {
            return Run(false, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        [CategoryID] AS Id,
                        [CategoryName] AS Name
                      FROM dbo.tblCategory
                      ORDER BY [CategoryName]"));
        }

        internal int Add(Category category)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblCategory
                        ([CategoryName], [Description],
                         [Notes/Remarks(Optional)])
                      OUTPUT INSERTED.[CategoryID]
                      VALUES (@name, @description, @notes)",
                    "@name", category.Name,
                    "@description", category.Description,
                    "@notes", category.Notes)));
        }

        internal void Update(Category category)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblCategory
                      SET [CategoryName] = @name,
                          [Description] = @description,
                          [Notes/Remarks(Optional)] = @notes
                      WHERE [CategoryID] = @id",
                    "@name", category.Name,
                    "@description", category.Description,
                    "@notes", category.Notes,
                    "@id", category.Id));

                return 0;
            });
        }
    }

    internal sealed class ProductRepository : RepositoryBase
    {
        internal ProductRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal DataTable GetAll()
        {
            return Run(true, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        [ProductID] AS Id,
                        [ProductName] AS Name,
                        [CategoryID] AS CategoryId,
                        [SupplierID] AS SupplierId,
                        Price,
                        [StockQuantity] AS StockQuantity,
                        [ProductStatus] AS Status,
                        RowVersion
                      FROM dbo.tblProducts
                      ORDER BY [ProductName]"));
        }

        internal int Add(Product product)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblProducts
                        ([ProductName], [CategoryID],
                         [SupplierID], Price,
                         [StockQuantity], [ProductStatus])
                      OUTPUT INSERTED.[ProductID]
                      VALUES
                        (@name, @category, @supplier,
                         @price, @stock, @status)",
                    "@name", product.Name,
                    "@category", product.CategoryId,
                    "@supplier", product.SupplierId,
                    "@price", product.Price,
                    "@stock", product.StockQuantity,
                    "@status", product.Status)));
        }

        internal void Update(Product product)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblProducts
                      SET [ProductName] = @name,
                          [CategoryID] = @category,
                          [SupplierID] = @supplier,
                          Price = @price,
                          [StockQuantity] = @stock,
                          [ProductStatus] = @status
                      WHERE [ProductID] = @id
                        AND RowVersion = @version",
                    "@name", product.Name,
                    "@category", product.CategoryId,
                    "@supplier", product.SupplierId,
                    "@price", product.Price,
                    "@stock", product.StockQuantity,
                    "@status", product.Status,
                    "@id", product.Id,
                    "@version", product.RowVersion));

                return 0;
            });
        }

        internal void Deactivate(int id)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblProducts
                      SET [ProductStatus] = 'Inactive'
                      WHERE [ProductID] = @id",
                    "@id", id));

                return 0;
            });
        }

        internal DataTable Search(
            string keyword,
            int? categoryId)
        {
            return Run(false, (connection, transaction) =>
            {
                if (categoryId.HasValue)
                {
                    int count = Convert.ToInt32(
                        Database.Scalar(
                            connection,
                            transaction,
                            @"SELECT COUNT(*)
                              FROM dbo.tblCategory
                              WHERE [CategoryID] = @id",
                            "@id", categoryId.Value));

                    if (count == 0)
                        throw new ArgumentException(
                            "Category not found.");
                }

                string role = Convert.ToString(
                    Database.Scalar(
                        connection,
                        transaction,
                        @"SELECT Role
                          FROM dbo.tblUser
                          WHERE UserID = @id",
                        "@id", Session.UserId.Value));

                string escapedKeyword = keyword
                    .Replace("~", "~~")
                    .Replace("%", "~%")
                    .Replace("_", "~_")
                    .Replace("[", "~[");

                return Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        p.[ProductID] AS Id,
                        p.[ProductName] AS Name,
                        p.[CategoryID] AS CategoryId,
                        c.[CategoryName] AS Category,
                        p.[SupplierID] AS SupplierId,
                        p.Price,
                        p.[StockQuantity] AS StockQuantity,
                        p.[ProductStatus] AS Status,
                        p.RowVersion,

                        CASE
                            WHEN p.[StockQuantity] = 0
                                THEN 'Out of Stock'
                            WHEN p.[StockQuantity] <= 5
                                THEN 'Low Stock'
                            ELSE 'In Stock'
                        END AS StockStatus

                      FROM dbo.tblProducts p

                      INNER JOIN dbo.tblCategory c
                        ON c.[CategoryID] = p.[CategoryID]

                      WHERE
                        p.[ProductName]
                            COLLATE Latin1_General_100_CI_AS
                            LIKE @keyword ESCAPE '~'

                        AND (@category IS NULL
                             OR p.[CategoryID] = @category)

                        AND (@admin = 1
                             OR p.[ProductStatus] = 'Active')

                      ORDER BY p.[ProductName]",
                    "@keyword", "%" + escapedKeyword + "%",
                    "@category", categoryId.HasValue
                        ? (object)categoryId.Value
                        : null,
                    "@admin", role == "Admin");
            });
        }

        internal int CountActive()
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"SELECT COUNT(*)
                      FROM dbo.tblProducts
                      WHERE [ProductStatus] = 'Active'")));
        }
    }

    internal sealed class SalesRepository : RepositoryBase
    {
        internal SalesRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal Receipt Complete(
            List<CartItem> items,
            decimal payment)
        {

            return Run(false, (connection, transaction) =>
            {
                // Use Philippine date for the transaction number
                DateTime philippineDate = DateTime.UtcNow.AddHours(8);

                string prefix = "CB-" +
                    philippineDate.ToString("yyyyMMdd") + "-";

                // Find the highest transaction number for this date.
                // The table lock prevents two simultaneous sales
                // from receiving the same transaction number.
                int lastNumber = Convert.ToInt32(
                    Database.Scalar(
                        connection,
                        transaction,
                        @"SELECT ISNULL(
                MAX(TRY_CONVERT(INT, RIGHT(TransactionNumber, 4))),
                0)
              FROM dbo.Sales WITH (TABLOCKX, HOLDLOCK)
              WHERE TransactionNumber LIKE
                @prefix + '[0-9][0-9][0-9][0-9]'",
                        "@prefix", prefix));

                if (lastNumber >= 9999)
                    throw new InvalidOperationException(
                        "Daily transaction limit reached.");

                string newTransactionNumber =
                    prefix + (lastNumber + 1).ToString("D4");

                var receipt = new Receipt
                {
                    TransactionNumber = newTransactionNumber,
                    SoldAtUtc = DateTime.UtcNow,
                    CashierId = Session.UserId.Value,
                    Payment = payment
                };


                foreach (CartItem item in
                    items.OrderBy(x => x.ProductId))
                {
                    DataTable table = Database.Table(
                        connection,
                        transaction,
                        @"SELECT
                            [ProductName] AS Name,
                            Price,
                            [StockQuantity] AS StockQuantity,
                            [ProductStatus] AS Status
                          FROM dbo.tblProducts
                            WITH (UPDLOCK, HOLDLOCK)
                          WHERE [ProductID] = @id",
                        "@id", item.ProductId);

                    if (table.Rows.Count != 1)
                        throw new InvalidOperationException(
                            "Product not found: " +
                            item.ProductId);

                    DataRow product = table.Rows[0];

                    if (Convert.ToString(product["Status"])
                        != "Active")
                    {
                        throw new InvalidOperationException(
                            "Inactive product: " +
                            product["Name"]);
                    }

                    if (Convert.ToInt32(
                        product["StockQuantity"])
                        < item.Quantity)
                    {
                        throw new InvalidOperationException(
                            "Insufficient stock: " +
                            product["Name"]);
                    }

                    var line = new ReceiptLine
                    {
                        ProductId = item.ProductId,
                        ProductName =
                            Convert.ToString(product["Name"]),
                        Quantity = item.Quantity,
                        UnitPrice =
                            Convert.ToDecimal(product["Price"])
                    };

                    receipt.Lines.Add(line);
                    receipt.Total += line.Subtotal;
                }

                if (payment < receipt.Total)
                    throw new ArgumentException(
                        "Payment is insufficient.");

                receipt.SaleId = Convert.ToInt64(
                    Database.Scalar(
                        connection,
                        transaction,
                        @"INSERT INTO dbo.Sales
                          (TransactionNumber, SoldAtUtc,
                           CashierId, Total, Payment, [Change])
                         OUTPUT INSERTED.SaleId
                         VALUES
                         (@number, @date,
                         @cashier, @total, @payment, @change)",
                        "@number", receipt.TransactionNumber,
                        "@date", receipt.SoldAtUtc,
                        "@cashier", receipt.CashierId,
                        "@total", receipt.Total,
                        "@payment", payment,
                        "@change", payment - receipt.Total));

                foreach (ReceiptLine line in receipt.Lines)
                {
                    Database.Execute(
                        connection,
                        transaction,
                        @"INSERT INTO dbo.SaleItems
                         (SaleId, ProductId, Quantity, UnitPrice, Subtotal)
                        VALUES
                         (@sale, @product, @quantity, @price, @subtotal)",
                        "@sale", receipt.SaleId,
                        "@product", line.ProductId,
                        "@quantity", line.Quantity,
                        "@price", line.UnitPrice,
                        "@subtotal", line.Subtotal);

                    Database.RequireRow(Database.Execute(
                        connection,
                        transaction,
                        @"UPDATE dbo.tblProducts
                          SET [StockQuantity] =
                              [StockQuantity] - @quantity
                          WHERE [ProductID] = @id
                            AND [StockQuantity] >= @quantity",
                        "@quantity", line.Quantity,
                        "@id", line.ProductId));
                }

                return receipt;
            });
        }
    }

    internal sealed class ReportRepository : RepositoryBase
    {
        internal ReportRepository(
            Database database,
            SessionContext session)
            : base(database, session)
        {
        }

        internal DataTable Inventory(
            int? categoryId,
            string stockStatus)
        {
            return Run(true, (connection, transaction) =>
            {
                if (categoryId.HasValue)
                {
                    int count = Convert.ToInt32(
                        Database.Scalar(
                            connection,
                            transaction,
                            @"SELECT COUNT(*)
                              FROM dbo.tblCategory
                              WHERE [CategoryID] = @id",
                            "@id", categoryId.Value));

                    if (count == 0)
                        throw new ArgumentException(
                            "Category not found.");
                }

                return Database.Table(
                    connection,
                    transaction,
                    @"SELECT * FROM
                      (
                        SELECT p.[ProductID] AS ProductId,
                               p.[ProductName] AS ProductName,
                               p.[CategoryID] AS CategoryId,
                               c.[CategoryName] AS Category,
                               p.[StockQuantity] AS CurrentStock,
                               p.[ProductStatus] AS ProductStatus,
                               CASE WHEN p.[StockQuantity] = 0 THEN 'Out of Stock'
                                    WHEN p.[StockQuantity] <= 5 THEN 'Low Stock'
                                    ELSE 'In Stock' END AS StockStatus
                        FROM dbo.tblProducts p
                        INNER JOIN dbo.tblCategory c ON c.[CategoryID] = p.[CategoryID]
                      ) AS inventory
                      WHERE (@category IS NULL OR CategoryId = @category)
                        AND (@status IS NULL OR StockStatus = @status)
                      ORDER BY ProductName",
                    "@category", categoryId.HasValue
                        ? (object)categoryId.Value
                        : null,
                    "@status", stockStatus);
            });
        }

        internal DataTable Sales(
            DateTime fromUtc,
            DateTime toExclusiveUtc)
        {
            return Run(true, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        s.SaleId AS TransactionId,
                        s.TransactionNumber,
                        s.SoldAtUtc,
                        u.Username AS Cashier,
                        s.Total,
                        s.Payment,
                        s.Payment - s.Total AS [Change]

                      FROM dbo.Sales s

                      INNER JOIN dbo.tblUser u
                        ON u.UserID = s.CashierId

                      WHERE s.SoldAtUtc >= @from
                        AND s.SoldAtUtc < @to

                      ORDER BY s.SoldAtUtc, s.SaleId",
                    "@from", fromUtc,
                    "@to", toExclusiveUtc));
        }
    }
}