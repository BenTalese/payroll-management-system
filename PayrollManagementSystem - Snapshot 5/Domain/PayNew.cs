namespace Domain
{
    public class PayNew : PayState
    {
        public PayNew(Payslip payslip) : base(payslip) { }

        public override PayStates State => PayStates.New;

        public override void Process(ref PayState _state)
        {
            _state = new PayProcessing(_payslip);
        }

        public override void Finalise(ref PayState _state)
        {
            throw new InvalidPayStateException("cannot finalise a payslip before processing it");
        }
    }
}