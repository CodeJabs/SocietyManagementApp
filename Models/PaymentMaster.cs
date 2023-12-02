namespace Models
{
    public class PaymentMaster
    {
        private int _iD;
        private string _paymentType;

        public int ID { get { return _iD; } set { _iD = value; } }

        public string paymentType { get { return _paymentType; } set { _paymentType = value; } }
    }
}
