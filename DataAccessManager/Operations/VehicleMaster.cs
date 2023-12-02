using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    internal class VehicleMaster
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public VehicleMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetVehicleMasterList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_VEHICLE_MASTER;            
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.VehicleMaster Add(Models.VehicleMaster vehicleMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_VEHICLE_TYPE;
            _sqlCommand.Parameters.AddWithValue("@VehicleType", vehicleMaster.VehicleType);            
            _sqlCommand.ExecuteNonQuery();
            return vehicleMaster;
        }

        public Models.VehicleMaster Update(Models.VehicleMaster vehicleMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_VEHICLE_TYPE;
            _sqlCommand.Parameters.AddWithValue("@Id", vehicleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@VehicleType", vehicleMaster.VehicleType);
            _sqlCommand.ExecuteNonQuery();
            return vehicleMaster;
        }

    }
}
