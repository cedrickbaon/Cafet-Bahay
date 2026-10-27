using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BusinessLogic.Repository;

namespace BusinessLogic
{
    public sealed class SessionContext
    {
        internal int? UserId { get; set; }

        public void Logout()
        {
            UserId = null;
        }

        internal void Demand(
            SqlConnection connection,
            SqlTransaction transaction,
            bool adminOnly)
        {
            if (!UserId.HasValue)
                throw new UnauthorizedAccessException(
                    "Please log in.");

            DataTable table = Database.Table(
                connection,
                transaction,
                @"SELECT Role
                  FROM dbo.tblUser WITH (HOLDLOCK)
                  WHERE UserID = @id
                    AND IsLocked = 0
                    AND PasswordHash IS NOT NULL",
                "@id", UserId.Value);

            if (table.Rows.Count != 1)
                throw new UnauthorizedAccessException(
                    "Account unavailable or locked.");

            string role =
                Convert.ToString(table.Rows[0]["Role"]);

            if (role != "Admin" && role != "Cashier")
                throw new UnauthorizedAccessException(
                    "Invalid saved role.");

            if (adminOnly && role != "Admin")
                throw new UnauthorizedAccessException(
                    "Only an Admin can perform this action.");
        }
    }

    internal static class PasswordHasher
    {
        private const int Iterations = 600000;

        internal static string Hash(string password)
        {
            byte[] salt = new byte[16];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            using (var hash = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                return Iterations + ":"
                    + Convert.ToBase64String(salt) + ":"
                    + Convert.ToBase64String(hash.GetBytes(32));
            }
        }

        internal static bool Verify(
            string password,
            string storedHash)
        {
            string[] parts = storedHash.Split(':');

            using (var hash = new Rfc2898DeriveBytes(
                password,
                Convert.FromBase64String(parts[1]),
                int.Parse(parts[0]),
                HashAlgorithmName.SHA256))
            {
                byte[] expected =
                    Convert.FromBase64String(parts[2]);

                byte[] actual = hash.GetBytes(32);

                int difference =
                    expected.Length ^ actual.Length;

                for (int i = 0;
                    i < actual.Length && i < expected.Length;
                    i++)
                {
                    difference |= actual[i] ^ expected[i];
                }

                return difference == 0;
            }
        }
    }
}

namespace BusinessLogic.Repository
{
    internal sealed class Database
    {
        private readonly string connectionString;

        internal Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal SqlConnection Open()
        {
            var connection =
                new SqlConnection(connectionString);

            try
            {
                connection.Open();
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }

        internal static SqlCommand Command(
            SqlConnection connection,
            SqlTransaction transaction,
            string sql,
            params object[] parameters)
        {
            var command =
                new SqlCommand(sql, connection, transaction);

            for (int i = 0; i < parameters.Length; i += 2)
            {
                string name = (string)parameters[i];

                object value =
                    parameters[i + 1] ?? DBNull.Value;

                SqlParameter parameter =
                    command.Parameters.AddWithValue(
                        name, value);

                if (value is decimal)
                {
                    parameter.SqlDbType = SqlDbType.Decimal;
                    parameter.Precision = 18;
                    parameter.Scale = 2;
                }
            }

            return command;
        }

        internal static DataTable Table(
            SqlConnection connection,
            SqlTransaction transaction,
            string sql,
            params object[] parameters)
        {
            using (SqlCommand command = Command(
                connection, transaction, sql, parameters))
            using (SqlDataReader reader =
                command.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }

        internal static object Scalar(
            SqlConnection connection,
            SqlTransaction transaction,
            string sql,
            params object[] parameters)
        {
            using (SqlCommand command = Command(
                connection, transaction, sql, parameters))
            {
                return command.ExecuteScalar();
            }
        }

        internal static int Execute(
            SqlConnection connection,
            SqlTransaction transaction,
            string sql,
            params object[] parameters)
        {
            using (SqlCommand command = Command(
                connection, transaction, sql, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        internal static void RequireRow(int count)
        {
            if (count != 1)
                throw new InvalidOperationException(
                    "Record not found or changed. Refresh and try again.");
        }
    }

    internal abstract class RepositoryBase
    {
        protected readonly Database Db;
        protected readonly SessionContext Session;

        protected RepositoryBase(
            Database database,
            SessionContext session)
        {
            Db = database;
            Session = session;
        }

        protected T Run<T>(
            bool adminOnly,
            Func<SqlConnection, SqlTransaction, T> operation)
        {
            using (SqlConnection connection = Db.Open())
            using (SqlTransaction transaction =
                connection.BeginTransaction(
                    IsolationLevel.Serializable))
            {
                try
                {
                    Session.Demand(
                        connection, transaction, adminOnly);

                    T result =
                        operation(connection, transaction);

                    transaction.Commit();
                    return result;
                }
                catch
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (SqlException)
                    {
                    }
                    catch (InvalidOperationException)
                    {
                    }

                    throw;
                }
            }
        }
    }
}