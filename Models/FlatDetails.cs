namespace Models
{
    public class FlatDetails
    {
        private int _iD;
        private Society _society;
        private int _flatNo;
        private string _flatOwner;
        private string _contactNo;
        private FlatOccupancyMaster _flatOccupanyMaster;

        public int ID { get { return _iD; }set { _iD = value; } }
        public Society Society { get { return _society; } set { _society = value; } }
        public int FlatNo { get { return _flatNo; } set { _flatNo = value; } }

        public string FlatOwner { get { return _flatOwner; } set { _flatOwner = value; } }
        public string ContactNo { get { return _contactNo; } set { _contactNo = value; } }

        
        public FlatOccupancyMaster FlatOccupanyMaster { get { return _flatOccupanyMaster; } set { _flatOccupanyMaster = value; } }


    }
}
