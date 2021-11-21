namespace Domain
{
    public class PayProcessing : PayState
    {
        public PayProcessing(Payslip payslip) : base(payslip) { }

        public override PayStates State => PayStates.Processing;

        public override void Process(ref PayState _state)
        {
            throw new InvalidPayStateException("this payslip is already being processed");
        }

        public override void Finalise(ref PayState _state)
        {
            _state = new PayFinalised(_payslip);
        }
    }
}