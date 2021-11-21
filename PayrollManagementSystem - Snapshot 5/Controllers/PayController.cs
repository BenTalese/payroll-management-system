using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class PayController
    {
        private readonly PayRepository _payRepo = new PayRepository();
        private static PayController _instance;

        private PayController() { }

        public static PayController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayController();
                }
                return _instance;
            }
        }

        public IEnumerable<Shift> GetShifts()
        {
            return _payRepo.GetShifts();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _payRepo.GetEmployees();
        }

        public IEnumerable<Shift> GetRosteredShiftsByEmployeeID(int id)
        {
            return _payRepo.GetRosteredShiftsByEmployeeID(id);
        }

        public void InsertShift(Shift s)
        {
            _payRepo.InsertShift(s);
        }

        public void InsertRosteredShift(Employee e, Shift s)
        {
            if (shiftAlreadyRostered(e, s))
            {
                throw new InvalidPayStateException("this employee has already been rostered for this shift");
            }
            else
            {
                _payRepo.InsertRosteredShift(e, s);
            }
        }

        private bool shiftAlreadyRostered(Employee e, Shift s)
        {
            var shifts = GetRosteredShiftsByEmployeeID(e.EmployeeID);
            foreach (var shift in shifts)
            {
                if (s.ShiftID == shift.ShiftID)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteShift(int id)
        {
            _payRepo.DeleteShift(id);
        }
    }
}
