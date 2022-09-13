using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT_Kursov_3.Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }

        public OrderDetails() { }
    }
}
