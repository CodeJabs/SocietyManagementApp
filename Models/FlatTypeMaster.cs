
namespace Models
{
    public class FlatTypeMaster
    {
        private int _iD;
        private string _flatType;
        private decimal _standardCharges;
        private int _societyID;
        public int ID { get { return _iD; }set { _iD = value; } }

        public string FlatType { get { return _flatType; } set { _flatType = value; } }

        public decimal StandardCharges { get { return _standardCharges; } set { _standardCharges = value;} }
        public int SocietyID { get { return _societyID; } set { _societyID = value; } }
    }
}
