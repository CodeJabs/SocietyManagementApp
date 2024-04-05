
namespace Models
{
    public class ParkingRecords
    {
        private int _id;
        private FlatDetails _flatDetails;
        private Society _society;
        private VehicleMaster _vehicleMaster;
        private string _parkingNo;
        private string _vehicleNumber;
        private double _parkingCharges;
        private string _vehicleType;
        public int ID { get { return _id; }set { _id = value; } }
        public FlatDetails FlatDetails { get { return _flatDetails; } set { _flatDetails = value; } }
        public Society Society { get { return _society; } set { _society = value; } }

        public VehicleMaster VehicleMaster { get { return _vehicleMaster; } set { _vehicleMaster = value; } }
        public string ParkinghNo { get { return _parkingNo; } set { _parkingNo = value; } }

        public string VehicleNumber { get { return _vehicleNumber; } set { _vehicleNumber = value; } }

        public double ParkingCharges { get { return _parkingCharges; } set { _parkingCharges = value; } }

        public string VehicleType { get { return _vehicleType; } set { _vehicleType = value; } }
    }
}
