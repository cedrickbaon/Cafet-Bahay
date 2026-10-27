namespace Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string Status { get; set; }

        public byte[] RowVersion { get; set; }

        // Names used by your original Product class
        public int ProductID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string ProductName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int CategoryID
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }

        public int SupplierID
        {
            get { return SupplierId; }
            set { SupplierId = value; }
        }
    }
}