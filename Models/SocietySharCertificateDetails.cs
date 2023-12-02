namespace Models
{
    public class SocietySharCertificateDetails
    {
        private int _iD;
        private Society _society;
        public int ID { get { return _iD; } set { _iD = value; } }
        public Society Society { get { return _society; } set { _society = value; } }
    }
}
