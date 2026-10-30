using BusinessLogic;
using BusinessLogic.Controller;

namespace UI
{
    internal static class AppServices
    {
        public static string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CafetBahay;Integrated Security=True";

        internal static readonly SessionContext Session =
            new SessionContext();

        internal static readonly UserController Users =
            new UserController(ConnectionString, Session);

        internal static readonly SupplierController Suppliers =
            new SupplierController(ConnectionString, Session);

        internal static readonly CategoryController Categories =
            new CategoryController(ConnectionString, Session);

        internal static readonly ProductController Products =
            new ProductController(ConnectionString, Session);

        internal static readonly SalesController Sales =
            new SalesController(ConnectionString, Session);

        internal static readonly ReportController Reports =
            new ReportController(ConnectionString, Session);
    }
}