using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{

    public class OccupancyMaster : IOccupancyMaster
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public OccupancyMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetOccupancyList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_OCCUPANCY_MASTER;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.OccupancyMaster Add(Models.OccupancyMaster occupancyMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_OCCUPANCY_MASTER;
            _sqlCommand.Parameters.AddWithValue("@OccupancyType", occupancyMaster.OccupancyType);
            _sqlCommand.ExecuteNonQuery();
            return occupancyMaster;

        }
    }
}
