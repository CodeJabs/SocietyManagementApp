namespace Models
{
    /// <summary>
    ///  For Society Service Packages 
    /// </summary>
    public class SocietyServicePackage
    {
        private int _iD;
        private string _Type =string.Empty;
        private int _PackagePrice;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public int PackagePrice
        {
            get { return _PackagePrice; }
            set { _PackagePrice = value; }
        }
    }
}
