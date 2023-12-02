using System.Security.Principal;
namespace Models
{
    /// <summary>
    /// Society Information
    /// </summary>
    public class Society
    {
        private int _iD;
        private string _Name;
        private string _Abbreviation;
        private string _Address;
        private int _TelephoneNumber;
        private SocietyServicePackage _societyServicePackage;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Abbreviation
        {
            get { return _Abbreviation; }
            set { _Abbreviation = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public int TelephoneNumber
        {
            get { return _TelephoneNumber; }
            set { _TelephoneNumber = value; }
        }
        public SocietyServicePackage societyServicePackage
        {
            get { return _societyServicePackage; }
            set { _societyServicePackage = value; }
        }
    }
}