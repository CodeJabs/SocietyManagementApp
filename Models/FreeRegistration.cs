namespace Models
{
    public class FreeRegistration
    {
        private int _iD;

        private string _societyName;

        private string _emailAddress;

        private int _contactNo;
        public int ID { get { return _iD; } set { _iD = value; } }

        public string SocietyName { get { return _societyName; } set { _societyName = value; } }

        public string EmailAddress { get { return _emailAddress; } set { _emailAddress = value; } }

        public int ContactNo { get { return _contactNo; } set { _contactNo = value; } }




    }
}
