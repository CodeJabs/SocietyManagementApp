using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface IVehicleMaster
=======
    internal interface IVehicleMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        DataSet GetVehicleMasterList();

        Models.VehicleMaster Add(Models.VehicleMaster vehicleMaster);

        Models.VehicleMaster Update(Models.VehicleMaster vehicleMaster);
    }

}
