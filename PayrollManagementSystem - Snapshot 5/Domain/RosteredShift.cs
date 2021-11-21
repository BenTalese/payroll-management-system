using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RosteredShift
    {
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }

        public RosteredShift(int e, int s)
        {
            EmployeeID = e;
            ShiftID = s;
        }
    }
}
