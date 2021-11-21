using Controllers;
using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new PayRepository();
            Employee e = repo.GetEmployee(11111);
            Console.WriteLine(e.FirstName + " " + e.LastName);

            Shift s = repo.GetShift(10101);
            Console.WriteLine(s.ShiftDate.ToShortDateString() + " " + s.StartTime + " " + s.EndTime);

            var pays = repo.GetPayslips();
            Payslip p = pays.First();

            var pay = PayController.Instance.GetShifts();

            var sft = new Shift();
            PayController.Instance.InsertShift(sft);

            Console.ReadKey();
        }
    }
}
