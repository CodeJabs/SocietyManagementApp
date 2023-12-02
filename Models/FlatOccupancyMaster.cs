namespace Models
{
    /// <summary>
    /// Contains Flat Occupancy Type
    /// </summary>
    public class FlatOccupancyMaster
    {
        private int _iD;
        private string _occupancyType;

        public int ID { get { return _iD; } set { _iD = value; } }

        public string OccupancyType { get { return _occupancyType; } set { _occupancyType = value; } }

    }
}
