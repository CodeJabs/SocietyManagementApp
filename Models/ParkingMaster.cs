namespace Models
{
    /// <summary>
    /// Parking Master which contains Types of Parking
    /// </summary>
    public class ParkingMaster
    {
        private int _iD;
        private string _parkingType;

        public int ID { get { return _iD; } set { _iD = value; } }

        public string ParkingType { get { return _parkingType; } set { _parkingType = value; } }
    }
}
