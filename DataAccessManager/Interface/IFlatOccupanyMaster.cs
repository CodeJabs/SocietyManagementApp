using System.Data;

namespace DataAccessManager.Interface
{
    public interface IFlatOccupanyMaster
    {
        public DataSet GetFlatOccupancyType();

        public Models.FlatOccupancyMaster Save(Models.FlatOccupancyMaster flatOccupancyMaster);
    }
}
