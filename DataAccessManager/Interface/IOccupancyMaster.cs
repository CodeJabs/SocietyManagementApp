using System.Data;

namespace DataAccessManager.Interface
{
    public interface IOccupancyMaster
    {
        DataSet GetOccupancyList();

        Models.OccupancyMaster Add(Models.OccupancyMaster occupancyMaster);
    }
}
