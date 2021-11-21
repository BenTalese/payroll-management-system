namespace Domain
{
    internal class PayFinalised : PayState
    {
        public PayFinalised(Payslip payslip) : base(payslip) { }

        public override PayStates State => PayStates.Finalised;

        public override void Process(ref PayState _state)
        {
            throw new InvalidPayStateException("cannot re-process a payment after it is finalised");
        }

        public override void Finalise(ref PayState _state)
        {
            throw new InvalidPayStateException("this payslip has already been finalised");
        }
    }
}