namespace Models
{
    public class SocietyNominationRegister
    {
        private int _id;
        private Society _society;
        private FlatDetails _flatDetails;
        
        public int ID { get { return _id; }set { _id = value; } }

        public Society Society { get { return _society; } set { _society = value; } }

        public FlatDetails FlatDetails { get { return _flatDetails; } set { _flatDetails = value; } }
    }
}
