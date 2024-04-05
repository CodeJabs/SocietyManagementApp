using System.Data;

namespace DataAccessManager.Interface
{
    public interface IParkingRecords
    {
        DataSet GetParkingRecord(int FlatId, int SocietyID);
        
        Models.ParkingRecords Add(Models.FlatDetails flatDetails, Models.VehicleMaster vehicleMaster, Models.ParkingRecords parkingRecords);

        Models.ParkingRecords Update(Models.FlatDetails flatDetails, Models.VehicleMaster vehicleMaster, Models.ParkingRecords parkingRecords);
    }
}
