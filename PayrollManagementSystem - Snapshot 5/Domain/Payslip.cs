using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Payslip
    {
        private PayState _state;
        public PayStates State { get => _state.State; }
        public event PropertyChangedEventHandler PropertyChanged;

        public int PayslipID { get; private set; }
        public int EmployeeID { get; private set; }
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
        public decimal HoursWorked { get; private set; }
        public decimal GrossPay { get; private set; }
        public decimal NetPay { get; private set; }
        public decimal Tax { get; private set; }


        public Payslip(int id, int e, DateTime pps, DateTime ppe, decimal hw, decimal gp, decimal np, decimal t, int stateID)
        {
            PayslipID = id;
            EmployeeID = e;
            PayPeriodStart = pps;
            PayPeriodEnd = ppe;
            HoursWorked = hw;
            GrossPay = gp;
            NetPay = np;
            Tax = t;
            setState(stateID);
        }


        // 1 = New, 2 = Processing, 3 = Finalised
        private void setState(int stateId)
        {
            switch (stateId)
            {
                case 1:
                    _state = new PayNew(this);
                    break;
                case 2:
                    _state = new PayProcessing(this);
                    break;
                case 3:
                    _state = new PayFinalised(this);
                    break;
                default:
                    throw new InvalidPayStateException($"Invalid state ID: {stateId}");
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
        }

        public void Process()
        {
            if (HoursWorked == 0)
            {
                throw new InvalidPayStateException("cannot process payslip if no shifts have been rostered");
            }
            _state.Process(ref _state);
        }

        public void Finalise()
        {
            if (GrossPay == 0 || NetPay == 0 || Tax == 0)
            {
                throw new InvalidPayStateException("cannot finalise a payslip before calculating all fields");
            }
            _state.Finalise(ref _state);
        }
    }
}
