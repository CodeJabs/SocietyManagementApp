

namespace Models
{
    public class SocietyFlatsBills
    {
        private int _iD;
        private Society _society;
        private FlatsBillingMaster _flatBillingMaster;
        private double _totalAmount;
        private DateTime _billIssueDate;
        private DateTime _billDueDate;
        private DateTime _createdDate;
        private string _remarks;

        public int ID { get { return _iD; }set { _iD = value; } }
        public Society Society { get { return _society; } set { _society = value; } }
        public FlatsBillingMaster FlatBillingMaster { get { return _flatBillingMaster; } set { _flatBillingMaster = value; } }
        public double TotalAmount { get { return _totalAmount; } set { _totalAmount = value; } }
        public DateTime BillIssueDate { get { return _billIssueDate; } set { _billIssueDate = value; } }
        public DateTime BillDueDate { get { return _billDueDate; } set { _billDueDate = value; } }

        public DateTime CreatedDate { get { return _createdDate; } set { _createdDate = value; } }

        public string Remarks { get { return _remarks; } set { _remarks = value; } }
    }
}
