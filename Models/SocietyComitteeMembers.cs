namespace Models
{
    public class SocietyComitteeMembers
    {
        private int _iD;
        private UserMaster _userMaster;
        private FlatDetails _flatDetails;
        private SocietyMemberMaster _societyMemberMaster;

      

        public int ID { get { return _iD; } set { _iD = value; } }

        public UserMaster UserMaster { get { return _userMaster; } set { _userMaster = value; } }

        public FlatDetails FlatDetails { get { return _flatDetails; } set { _flatDetails = value; } }

        public SocietyMemberMaster SocietyMemberMaster { get { return _societyMemberMaster; } set { _societyMemberMaster = value; } }



    }
}
