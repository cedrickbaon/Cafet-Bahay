using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Model;

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
                        PasswordHash,
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

                if (row.IsNull("PasswordHash"))
                {
                    transaction.Commit();

                    throw new UnauthorizedAccessException(
                        "Account needs a password reset. Contact an Admin.");
                }

                string role =
                    Convert.ToString(row["Role"]);

                if (role != "Admin" && role != "Cashier")
                {
                    transaction.Commit();

                    throw new UnauthorizedAccessException(
                        "Invalid saved role.");
                }

                


                // ETO AKIN TO
                bool validPassword = true;
                // HANGGANG DITO LANG


                // CEDRICK PINALTAN KO MUNA NG TRUE PARA LANG MABUKSAN YUNG MGA
                // PANELS, CHINECK KO LANG KASI KUNG OKAY NA YUNG MGA DESIGNS

                // ETO CODE MO. DITO 
                //bool validPassword = PasswordHasher.Verify(
                //  password,
                //  Convert.ToString(row["PasswordHash"]));
                //HANGGANG DITO


                if (!validPassword)
                {
                    int attempts =
                        Convert.ToInt32(row["FailedAttempts"]) + 1;

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
                    Username =
                        Convert.ToString(row["Username"]),
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
            string passwordHash,
            string role)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblUser
                        (Username, PasswordHash, Role)
                      OUTPUT INSERTED.UserID
                      VALUES (@username, @hash, @role)",
                    "@username", username,
                    "@hash", passwordHash,
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
            string passwordHash)
        {
            Run(true, (connection, transaction) =>
            {
                Database.RequireRow(Database.Execute(
                    connection,
                    transaction,
                    @"UPDATE dbo.tblUser
                      SET PasswordHash = @hash,
                          [Password] = NULL,
                          FailedAttempts = 0,
                          IsLocked = 0
                      WHERE UserID = @id",
                    "@hash", passwordHash,
                    "@id", id));

                return 0;
            });
        }

        internal void Bootstrap(
            string adminUsername,
            string adminHash,
            string cashierUsername,
            string cashierHash)
        {
            using (var connection = Db.Open())
            using (var transaction = connection.BeginTransaction(
                IsolationLevel.Serializable))
            {
                DataTable users = Database.Table(
                    connection,
                    transaction,
                    @"SELECT UserID, Username, PasswordHash
                      FROM dbo.tblUser WITH (UPDLOCK, HOLDLOCK)");

                foreach (DataRow row in users.Rows)
                {
                    if (!row.IsNull("PasswordHash"))
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
                        SET PasswordHash = @hash,
                            [Password] = NULL,
                            Role = @role,
                            FailedAttempts = 0,
                            IsLocked = 0
                        WHERE Username = @username;
                    END
                    ELSE
                    BEGIN
                        INSERT INTO dbo.tblUser
                            (Username, PasswordHash, Role)
                        VALUES (@username, @hash, @role);
                    END;";

                Database.Execute(
                    connection,
                    transaction,
                    sql,
                    "@username", adminUsername,
                    "@hash", adminHash,
                    "@role", "Admin");

                Database.Execute(
                    connection,
                    transaction,
                    sql,
                    "@username", cashierUsername,
                    "@hash", cashierHash,
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
                        [Supplier ID] AS Id,
                        [Supplier Name] AS Name,
                        [Products Supplied] AS ProductsSupplied,
                        [Contact Person] AS ContactPerson,
                        [Contact Number] AS ContactNumber,
                        [Email Address] AS Email,
                        [Address] AS Address,
                        [Status] AS Status,
                        [Notes/Remarks (Optional)] AS Notes
                      FROM dbo.tblSupplierTable
                      ORDER BY [Supplier Name]"));
        }

        internal int Add(Supplier supplier)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblSupplierTable
                        ([Supplier Name], [Products Supplied],
                         [Contact Person], [Contact Number],
                         [Email Address], [Address],
                         [Status], [Notes/Remarks (Optional)])
                      OUTPUT INSERTED.[Supplier ID]
                      VALUES
                        (@name, @products, @person, @phone,
                         @email, @address, @status, @notes)",
                    "@name", supplier.Name,
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
                      SET [Supplier Name] = @name,
                          [Products Supplied] = @products,
                          [Contact Person] = @person,
                          [Contact Number] = @phone,
                          [Email Address] = @email,
                          [Address] = @address,
                          [Status] = @status,
                          [Notes/Remarks (Optional)] = @notes
                      WHERE [Supplier ID] = @id",
                    "@name", supplier.Name,
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
                      WHERE [Supplier ID] = @id",
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
                      WHERE [Supplier ID] = @id",
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
                        [Category ID] AS Id,
                        [Category Name] AS Name,
                        [Description] AS Description,
                        [Notes/Remarks (Optional)] AS Notes
                      FROM dbo.tblCategory
                      ORDER BY [Category Name]"));
        }

        internal DataTable Lookup()
        {
            return Run(false, (connection, transaction) =>
                Database.Table(
                    connection,
                    transaction,
                    @"SELECT
                        [Category ID] AS Id,
                        [Category Name] AS Name
                      FROM dbo.tblCategory
                      ORDER BY [Category Name]"));
        }

        internal int Add(Category category)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblCategory
                        ([Category Name], [Description],
                         [Notes/Remarks (Optional)])
                      OUTPUT INSERTED.[Category ID]
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
                      SET [Category Name] = @name,
                          [Description] = @description,
                          [Notes/Remarks (Optional)] = @notes
                      WHERE [Category ID] = @id",
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
                        [Product ID] AS Id,
                        [Product Name] AS Name,
                        [Category ID] AS CategoryId,
                        [Supplier ID] AS SupplierId,
                        Price,
                        [Stock Quantity] AS StockQuantity,
                        [Product Status] AS Status,
                        RowVersion
                      FROM dbo.tblProducts
                      ORDER BY [Product Name]"));
        }

        internal int Add(Product product)
        {
            return Run(true, (connection, transaction) =>
                Convert.ToInt32(Database.Scalar(
                    connection,
                    transaction,
                    @"INSERT INTO dbo.tblProducts
                        ([Product Name], [Category ID],
                         [Supplier ID], Price,
                         [Stock Quantity], [Product Status])
                      OUTPUT INSERTED.[Product ID]
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
                      SET [Product Name] = @name,
                          [Category ID] = @category,
                          [Supplier ID] = @supplier,
                          Price = @price,
                          [Stock Quantity] = @stock,
                          [Product Status] = @status
                      WHERE [Product ID] = @id
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
                      SET [Product Status] = 'Inactive'
                      WHERE [Product ID] = @id",
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
                              WHERE [Category ID] = @id",
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
                        p.[Product ID] AS Id,
                        p.[Product Name] AS Name,
                        p.[Category ID] AS CategoryId,
                        c.[Category Name] AS Category,
                        p.[Supplier ID] AS SupplierId,
                        p.Price,
                        p.[Stock Quantity] AS StockQuantity,
                        p.[Product Status] AS Status,
                        p.RowVersion,

                        CASE
                            WHEN p.[Stock Quantity] = 0
                                THEN 'Out of Stock'
                            WHEN p.[Stock Quantity] <= 5
                                THEN 'Low Stock'
                            ELSE 'In Stock'
                        END AS StockStatus

                      FROM dbo.tblProducts p

                      INNER JOIN dbo.tblCategory c
                        ON c.[Category ID] = p.[Category ID]

                      WHERE
                        p.[Product Name]
                            COLLATE Latin1_General_100_CI_AS
                            LIKE @keyword ESCAPE '~'

                        AND (@category IS NULL
                             OR p.[Category ID] = @category)

                        AND (@admin = 1
                             OR p.[Product Status] = 'Active')

                      ORDER BY p.[Product Name]",
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
                      WHERE [Product Status] = 'Active'")));
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
                var receipt = new Receipt
                {
                    TransactionNumber =
                        Guid.NewGuid().ToString("N"),
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
                            [Product Name] AS Name,
                            Price,
                            [Stock Quantity] AS StockQuantity,
                            [Product Status] AS Status
                          FROM dbo.tblProducts
                            WITH (UPDLOCK, HOLDLOCK)
                          WHERE [Product ID] = @id",
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
                             CashierId, Total, Payment)
                          OUTPUT INSERTED.Id
                          VALUES
                            (@number, @date,
                             @cashier, @total, @payment)",
                        "@number", receipt.TransactionNumber,
                        "@date", receipt.SoldAtUtc,
                        "@cashier", receipt.CashierId,
                        "@total", receipt.Total,
                        "@payment", payment));

                foreach (ReceiptLine line in receipt.Lines)
                {
                    Database.Execute(
                        connection,
                        transaction,
                        @"INSERT INTO dbo.SaleItems
                            (SaleId, ProductId, ProductName,
                             Quantity, UnitPrice)
                          VALUES
                            (@sale, @product, @name,
                             @quantity, @price)",
                        "@sale", receipt.SaleId,
                        "@product", line.ProductId,
                        "@name", line.ProductName,
                        "@quantity", line.Quantity,
                        "@price", line.UnitPrice);

                    Database.RequireRow(Database.Execute(
                        connection,
                        transaction,
                        @"UPDATE dbo.tblProducts
                          SET [Stock Quantity] =
                              [Stock Quantity] - @quantity
                          WHERE [Product ID] = @id
                            AND [Stock Quantity] >= @quantity",
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
                              WHERE [Category ID] = @id",
                            "@id", categoryId.Value));

                    if (count == 0)
                        throw new ArgumentException(
                            "Category not found.");
                }

                return Database.Table(
                    connection,
                    transaction,
                    @"SELECT *
                      FROM dbo.vwInventory
                      WHERE
                        (@category IS NULL
                         OR CategoryId = @category)

                        AND (@status IS NULL
                             OR StockStatus = @status)

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
                        s.Id AS TransactionId,
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

                      ORDER BY s.SoldAtUtc, s.Id",
                    "@from", fromUtc,
                    "@to", toExclusiveUtc));
        }
    }
}