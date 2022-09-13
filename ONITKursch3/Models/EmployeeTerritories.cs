using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT_Kursov_3.Models
{
    public class EmployeeTerritories
    {
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public EmployeeTerritories() { }

        public EmployeeTerritories(int employeeID, string territoryID)
        {
            EmployeeID = employeeID;
            TerritoryID = territoryID;
        }
    }
}
