using System.Diagnostics;
using System.Net.Http.Headers;

namespace Models
{
    public class UserMaster
    {
        private int _userID;

        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private RoleMaster _roleMaster;
        private int _mobileNo;
        private string _emailID;
        private Society _society;
        private short _isUserLocked;
        private bool _isUserDeleted;
        private int _createdBy;
        
        public int UserID { get { return _userID; } set { _userID = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        public string UserName { get { return _userName; } set { _userName = value; } }

        public string Password { get { return _password; } set { _password = value; } }

        public RoleMaster RoleMaster { get { return _roleMaster; } set { _roleMaster = value; } }

        public int MobileNo { get { return _mobileNo; } set { _mobileNo = value; } }

        public string EmailId { get { return _emailID; } set { _emailID = value; } }

        public Society Society { get { return _society; } set { _society = value; } }

        public short IsUserLocked { get { return _isUserLocked; } set { _isUserLocked = value; } }

        public bool IsUserDeleted { get { return _isUserDeleted; } set { _isUserDeleted = value; } }

        public int CreatedBy { get { return _createdBy; } set { _createdBy = value; } }



    }
}
