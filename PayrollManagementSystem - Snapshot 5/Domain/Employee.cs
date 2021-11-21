using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PayRate { get; set; }
        public decimal YearToDate { get; set; }

        public Employee(int id, string fName, string lName, decimal rate, decimal ytd)
        {
            EmployeeID = id;
            FirstName = fName;
            LastName = lName;
            PayRate = rate;
            YearToDate = ytd;
        }
    }
}
