using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum PayStates { New = 1, Processing = 2, Finalised = 3 }

    public abstract class PayState
    {
        protected Payslip _payslip;
        public PayState(Payslip payslip)
        {
            _payslip = payslip;
        }

        public abstract PayStates State { get; }
        public abstract void Process(ref PayState _state);
        public abstract void Finalise(ref PayState _state);
    }
}
