

namespace Models
{
    /// <summary>
    /// Class represent Types Occupancy in Society  already Flat Occupancy Master class created.
    /// </summary>
    public class OccupancyMaster
    {
        private int _iD;
        private string _occupancyType;

        public int ID { get { return _iD; } set { _iD = value; } }

        public string OccupancyType { get { return _occupancyType; } set { _occupancyType = value; } }
    }
}
