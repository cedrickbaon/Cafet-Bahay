using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ProductsSupplied { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
