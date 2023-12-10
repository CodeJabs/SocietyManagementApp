using System.Data;

namespace DataAccessManager.Interface
{

    public interface IVehicleMaster
    {
        DataSet GetVehicleMasterList();

        Models.VehicleMaster Add(Models.VehicleMaster vehicleMaster);

        Models.VehicleMaster Update(Models.VehicleMaster vehicleMaster);
    }

}
