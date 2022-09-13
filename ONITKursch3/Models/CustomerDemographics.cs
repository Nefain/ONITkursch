using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT_Kursov_3.Models
{
    public class CustomerDemographics
    {
        public string CustomerID { get; set; }
        public string CustomerTypeID { get; set; }

        public CustomerDemographics() { }

        public CustomerDemographics(string customerID, string customerTypeID)
        {
            CustomerID = customerID;
            CustomerTypeID = customerTypeID;
        }
    }
}
