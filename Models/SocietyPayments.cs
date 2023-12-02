namespace Models
{
    public class SocietyPayments
    {
        private int _iD;
        private int _invoiceID;
        private DateTime _fromDate;
        private DateTime _toDate;
        private PaymentMaster _paymentMaster;
        private UserMaster _userMaster;
        private Society _society;

        public int ID { get { return _iD; }set { _iD = value; } }

        public int InvoiceID { get { return _invoiceID; } set { _invoiceID = value; } }

        public DateTime FromDate { get { return _fromDate; } set { _fromDate = value; } }

        public DateTime ToDate { get { return _toDate; } set { _toDate = value; } }

        public PaymentMaster PaymentMaster { get { return _paymentMaster; } set { _paymentMaster = value; } }

        public UserMaster UserMaster { get { return _userMaster; } set { _userMaster = value; } }

        public Society Society { get { return _society; } set { _society = value; } }
    }
}
