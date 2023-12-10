using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{

    public class RoleMaster : IRoleMaster

    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public RoleMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetRoleMasterList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_ROLE_MASTER;
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.RoleMaster Add(Models.RoleMaster roleMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_ROLE_MASTER;
            _sqlCommand.Parameters.AddWithValue("@RoleName", roleMaster.RoleName);
            _sqlCommand.ExecuteNonQuery();
            return roleMaster;
        }

        public Models.RoleMaster Update(Models.RoleMaster roleMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_ROLE_MASTER;
            _sqlCommand.Parameters.AddWithValue("@ID", roleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@RoleName", roleMaster.RoleName);
            _sqlCommand.ExecuteNonQuery();
            return roleMaster;
        }
    }
}
