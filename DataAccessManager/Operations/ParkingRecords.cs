using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    

    public class ParkingRecords : IParkingRecords
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public ParkingRecords()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetParkingRecord(Models.FlatDetails flatDetails)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_PARKING_MASTER;
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatDetails.Society.ID);            
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.ParkingRecords Add(Models.FlatDetails flatDetails,Models.VehicleMaster vehicleMaster,Models.ParkingRecords parkingRecords)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_PARKING_RECORD;
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatDetails.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@VehicleTypeId", vehicleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@ParkingNo", parkingRecords.ParkinghNo);
            _sqlCommand.Parameters.AddWithValue("@VehicleNumber", parkingRecords.VehicleNumber);
            _sqlCommand.Parameters.AddWithValue("@ParkingCharges", parkingRecords.ParkingCharges);
            _sqlCommand.ExecuteNonQuery();
            return parkingRecords;
        }

        public Models.ParkingRecords Update(Models.FlatDetails flatDetails, Models.VehicleMaster vehicleMaster, Models.ParkingRecords parkingRecords)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_PARKING_RECORD;
            _sqlCommand.Parameters.AddWithValue("@ID", parkingRecords.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatDetails.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@VehicleTypeId", vehicleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@ParkingNo", parkingRecords.ParkinghNo);
            _sqlCommand.Parameters.AddWithValue("@VehicleNumber", parkingRecords.VehicleNumber);
            _sqlCommand.Parameters.AddWithValue("@ParkingCharges", parkingRecords.ParkingCharges);
            _sqlCommand.ExecuteNonQuery();
            return parkingRecords;
        }
    }
}
