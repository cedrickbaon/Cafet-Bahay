using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    internal static class Validation
    {
        internal static string Required(
            string value,
            string field,
            int maximumLength)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(
                    field + " is required.");

            value = value.Trim();

            if (value.Length > maximumLength)
                throw new ArgumentException(
                    field + " is too long.");

            return value;
        }

        internal static void Optional(
            string value,
            string field,
            int maximumLength)
        {
            if (value != null &&
                value.Length > maximumLength)
            {
                throw new ArgumentException(
                    field + " is too long.");
            }
        }

        internal static void Id(int id)
        {
            if (id <= 0)
                throw new ArgumentException(
                    "Select a valid record ID.");
        }

        internal static void Role(string role)
        {
            if (role != "Admin" && role != "Cashier")
                throw new ArgumentException(
                    "Role must be Admin or Cashier.");
        }

        internal static void Status(string status)
        {
            if (status != "Active" && status != "Inactive")
                throw new ArgumentException(
                    "Status must be Active or Inactive.");
        }

        internal static void Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                password.Length < 8 ||
                password.Length > 128)
            {
                throw new ArgumentException(
                    "Password must contain 8 to 128 characters.");
            }
        }

        internal static void Money(
            decimal amount,
            string field,
            bool mustBePositive)
        {
            bool invalidSign = mustBePositive
                ? amount <= 0
                : amount < 0;

            if (invalidSign ||
                amount > 9999999999999999.99m ||
                decimal.Round(amount, 2) != amount)
            {
                throw new ArgumentException(
                    field +
                    " must be a valid amount with at most two decimal places.");
            }
        }
    }

    public sealed class UserController
    {
        private readonly UserRepository repository;
        private readonly SessionContext session;

        public UserController(
            string connectionString,
            SessionContext session)
        {
            this.session = session;

            repository = new UserRepository(
                new Database(connectionString), session);
        }

        public UserAccount Login(
            string username,
            string password)
        {
            session.Logout();

            username = Validation.Required(
                username, "Username", 100);

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(
                    "Password is required.");

            if (password.Length > 128)
                throw new ArgumentException(
                    "Password is too long.");

            return repository.Login(username, password);
        }

        public void Logout()
        {
            session.Logout();
        }

        public DataTable GetAll()
        {
            return repository.GetAll();
        }

        public int Create(
            string username,
            string password,
            string role)
        {
            username = Validation.Required(
                username, "Username", 100);

            Validation.Password(password);
            Validation.Role(role);

            return repository.Create(
                username,
                PasswordHasher.Hash(password),
                role);
        }

        public void ChangeRole(int userId, string role)
        {
            Validation.Id(userId);
            Validation.Role(role);

            repository.ChangeRole(userId, role);
        }

        public void Delete(int userId)
        {
            Validation.Id(userId);
            repository.Delete(userId);
        }

        public void ResetPasswordAndUnlock(
            int userId,
            string newPassword)
        {
            Validation.Id(userId);
            Validation.Password(newPassword);

            repository.ResetPassword(
                userId,
                PasswordHasher.Hash(newPassword));
        }

        public void InitializeFirstRun(
            string adminUsername,
            string adminPassword,
            string cashierUsername,
            string cashierPassword)
        {
            adminUsername = Validation.Required(
                adminUsername, "Admin username", 100);

            cashierUsername = Validation.Required(
                cashierUsername, "Cashier username", 100);

            if (string.Equals(
                adminUsername,
                cashierUsername,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "Usernames must be different.");
            }

            Validation.Password(adminPassword);
            Validation.Password(cashierPassword);

            repository.Bootstrap(
                adminUsername,
                PasswordHasher.Hash(adminPassword),
                cashierUsername,
                PasswordHasher.Hash(cashierPassword));
        }
    }

    public sealed class SupplierController
    {
        private readonly SupplierRepository repository;

        public SupplierController(
            string connectionString,
            SessionContext session)
        {
            repository = new SupplierRepository(
                new Database(connectionString), session);
        }

        public DataTable GetAll()
        {
            return repository.GetAll();
        }

        public int Add(Supplier supplier)
        {
            Validate(supplier);
            return repository.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            Validate(supplier);
            Validation.Id(supplier.Id);

            repository.Update(supplier);
        }

        public void Deactivate(int supplierId)
        {
            Validation.Id(supplierId);
            repository.Deactivate(supplierId);
        }

        public void Delete(int supplierId)
        {
            Validation.Id(supplierId);
            repository.Delete(supplierId);
        }

        private static void Validate(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(
                    nameof(supplier));

            supplier.Name = Validation.Required(
                supplier.Name, "Supplier name", 150);

            supplier.Address = Validation.Required(
                supplier.Address, "Address", 500);

            Validation.Status(supplier.Status);

            Validation.Optional(
                supplier.ProductsSupplied,
                "Products supplied", 500);

            Validation.Optional(
                supplier.ContactPerson,
                "Contact person", 150);

            Validation.Optional(
                supplier.ContactNumber,
                "Contact number", 30);

            Validation.Optional(
                supplier.Email, "Email", 254);

            Validation.Optional(
                supplier.Notes, "Notes", 1000);

            if (!string.IsNullOrWhiteSpace(
                supplier.ContactNumber))
            {
                supplier.ContactNumber =
                    supplier.ContactNumber.Trim();

                int digits = supplier.ContactNumber.Count(
                    c => c >= '0' && c <= '9');

                if (digits < 7 ||
                    digits > 15 ||
                    !Regex.IsMatch(
                        supplier.ContactNumber,
                        @"^\+?[0-9 ()-]+$"))
                {
                    throw new ArgumentException(
                        "Invalid contact number.");
                }
            }

            if (!string.IsNullOrWhiteSpace(supplier.Email))
            {
                supplier.Email = supplier.Email.Trim();

                try
                {
                    var email =
                        new MailAddress(supplier.Email);

                    if (email.Address != supplier.Email)
                        throw new FormatException();
                }
                catch (FormatException)
                {
                    throw new ArgumentException(
                        "Invalid email address.");
                }
            }
        }
    }

    public sealed class CategoryController
    {
        private readonly CategoryRepository repository;

        public CategoryController(
            string connectionString,
            SessionContext session)
        {
            repository = new CategoryRepository(
                new Database(connectionString), session);
        }

        public DataTable GetAll()
        {
            return repository.GetAll();
        }

        public DataTable Lookup()
        {
            return repository.Lookup();
        }

        public int Add(Category category)
        {
            Validate(category);
            return repository.Add(category);
        }

        public void Update(Category category)
        {
            Validate(category);
            Validation.Id(category.Id);

            repository.Update(category);
        }

        private static void Validate(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(
                    nameof(category));

            category.Name = Validation.Required(
                category.Name, "Category name", 100);

            category.Description = Validation.Required(
                category.Description, "Description", 500);

            Validation.Optional(
                category.Notes, "Notes", 1000);
        }
    }

    public sealed class ProductController
    {
        private readonly ProductRepository repository;

        public ProductController(
            string connectionString,
            SessionContext session)
        {
            repository = new ProductRepository(
                new Database(connectionString), session);
        }

        public DataTable GetAll()
        {
            return repository.GetAll();
        }

        public int Add(Product product)
        {
            Validate(product);
            return repository.Add(product);
        }

        public void Update(Product product)
        {
            Validate(product);
            Validation.Id(product.Id);

            if (product.RowVersion == null ||
                product.RowVersion.Length != 8)
            {
                throw new ArgumentException(
                    "Reload the product before editing.");
            }

            repository.Update(product);
        }

        public void Deactivate(int productId)
        {
            Validation.Id(productId);
            repository.Deactivate(productId);
        }

        public DataTable Search(
            string keyword = "",
            int? categoryId = null)
        {
            Validation.Optional(
                keyword, "Search keyword", 150);

            if (categoryId.HasValue)
                Validation.Id(categoryId.Value);

            return repository.Search(
                keyword ?? "", categoryId);
        }

        public int CountActiveInventoryItems()
        {
            return repository.CountActive();
        }

        private static void Validate(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(
                    nameof(product));

            product.Name = Validation.Required(
                product.Name, "Product name", 150);

            Validation.Id(product.CategoryId);
            Validation.Id(product.SupplierId);
            Validation.Money(product.Price, "Price", true);
            Validation.Status(product.Status);

            if (product.StockQuantity < 0)
                throw new ArgumentException(
                    "Stock quantity cannot be negative.");
        }
    }

    public sealed class SalesController
    {
        private readonly SalesRepository repository;

        public SalesController(
            string connectionString,
            SessionContext session)
        {
            repository = new SalesRepository(
                new Database(connectionString), session);
        }

        public Receipt CompleteSale(
            IEnumerable<CartItem> cart,
            decimal payment)
        {
            if (cart == null)
                throw new ArgumentNullException(
                    nameof(cart));

            List<CartItem> items = cart.ToList();

            if (items.Count == 0)
                throw new ArgumentException(
                    "Sale must contain at least one product.");

            foreach (CartItem item in items)
            {
                if (item == null)
                    throw new ArgumentException(
                        "Invalid cart item.");

                Validation.Id(item.ProductId);

                if (item.Quantity <= 0)
                    throw new ArgumentException(
                        "Quantity must be a positive integer.");
            }

            List<CartItem> merged = items
                .GroupBy(item => item.ProductId)
                .Select(group => new CartItem
                {
                    ProductId = group.Key,
                    Quantity =
                        group.Sum(item => item.Quantity)
                })
                .ToList();

            Validation.Money(
                payment, "Payment", false);

            return repository.Complete(
                merged, payment);
        }
    }

    public sealed class ReportController
    {
        private readonly ReportRepository repository;

        public ReportController(
            string connectionString,
            SessionContext session)
        {
            repository = new ReportRepository(
                new Database(connectionString), session);
        }

        public DataTable Inventory(
            int? categoryId = null,
            string stockStatus = null)
        {
            if (categoryId.HasValue)
                Validation.Id(categoryId.Value);

            if (stockStatus != null &&
                stockStatus != "In Stock" &&
                stockStatus != "Low Stock" &&
                stockStatus != "Out of Stock")
            {
                throw new ArgumentException(
                    "Invalid stock status.");
            }

            return repository.Inventory(
                categoryId, stockStatus);
        }

        public DataTable Sales(
            DateTime fromUtc,
            DateTime toExclusiveUtc)
        {
            if (fromUtc.Kind != DateTimeKind.Utc ||
                toExclusiveUtc.Kind != DateTimeKind.Utc ||
                fromUtc >= toExclusiveUtc ||
                fromUtc.Year < 1753 ||
                toExclusiveUtc.Year < 1753)
            {
                throw new ArgumentException(
                    "Supply a valid UTC date range. End is exclusive.");
            }

            return repository.Sales(
                fromUtc, toExclusiveUtc);
        }
    }
}