namespace Models
{
    public class SocietyVisitorsRecord
    {
        private int _iD;
        private Society _society;
        private VisitorTypeMaster _visitorTypeMaster;
        private string _name;
        private int _contactNo;
        private string _fromLocation;
        private DateTime _entryTime;
        private DateTime _outTime;
        public int ID { get { return _iD; } set { _iD = value; } }
        public Society Society { get { return _society; } set { _society = value; } }

        public VisitorTypeMaster VisitorTypeMaster { get { return _visitorTypeMaster; } set { _visitorTypeMaster = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public int ContactNo { get { return _contactNo; } set { _contactNo = value; } }

        public string FromLocation { get { return _fromLocation; } set { _fromLocation = value; } }

        public DateTime EntryTime { get { return _entryTime; } set { _entryTime = value; } }
        public DateTime OutTime { get { return _outTime; } set { _outTime = value; } }
    }
}
