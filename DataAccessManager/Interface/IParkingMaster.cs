using System.Data;

namespace DataAccessManager.Interface
{
    public interface IParkingMaster
    {
        DataSet GetParkingMasterList();

        Models.ParkingMaster Add(Models.ParkingMaster parkingMaster);
    }
}
