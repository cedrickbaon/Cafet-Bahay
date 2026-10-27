namespace Model
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductsSupplied { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        // Names used by your original Supplier class
        public int SupplierID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string SupplierName
        {
            get { return Name; }
            set { Name = value; }
        }

        public string EmailAddress
        {
            get { return Email; }
            set { Email = value; }
        }
    }
}