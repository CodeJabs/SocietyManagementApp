namespace Models
{
    public class RoleMaster
    {
        private int _iD;
        private string _roleName;

        public int ID { get { return _iD; } set { _iD = value; } }
        public string RoleName { get { return _roleName; } set { _roleName = value; } }
    }
}
