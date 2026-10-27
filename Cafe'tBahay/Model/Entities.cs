using System;
using System.Collections.Generic;

namespace Model
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsLocked { get; set; }
        public int FailedAttempts { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ReceiptLine
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Subtotal
        {
            get { return Quantity * UnitPrice; }
        }
    }

    public class Receipt
    {
        public long SaleId { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime SoldAtUtc { get; set; }
        public int CashierId { get; set; }
        public decimal Total { get; set; }
        public decimal Payment { get; set; }

        public decimal Change
        {
            get { return Payment - Total; }
        }

        public List<ReceiptLine> Lines { get; set; }
            = new List<ReceiptLine>();
    }
}