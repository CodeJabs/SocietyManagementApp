namespace Models
{
    public class VehicleMaster
    {
        private int _iD;
        private string _vehicleType;

        public int ID { get { return _iD; } set { _iD = value; } }

        public string VehicleType { get { return _vehicleType; } set { _vehicleType = value; } }
    }
}
