namespace Models
{
    public class FlatPayments
    {
        private int _iD;
        private int _invoiceID;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private PaymentMaster _paymentMaster;
        private UserMaster _userMaster;
        private FlatDetails _flatDetails;
        private Society _society;

        public int ID { get { return _iD; }set { _iD = value; } }
        public int InvoiceID { get { return _invoiceID; } set { _invoiceID = value; } }
        public DateTime FromDate { get { return _FromDate; } set { _FromDate = value; } }
        public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }
        public UserMaster UserMaster { get { return _userMaster; } set { _userMaster = value; } }
        public PaymentMaster PaymentMaster { get { return _paymentMaster; } set { _paymentMaster = value; } }

        public Society Society { get { return _society; } set { _society = value; } }

        public FlatDetails FlatDetails { get { return _flatDetails; } set { _flatDetails = value; } }


    }
}
