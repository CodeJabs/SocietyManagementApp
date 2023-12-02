using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class FreeRegistration : IFreeRegistration
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public FreeRegistration()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetFreeRegistration()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FREE_REGISTRATION;
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public bool Add(Models.FreeRegistration freeRegistration)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_FREE_REGISTRATION;
            _sqlCommand.Parameters.AddWithValue("@SocietyName", freeRegistration.SocietyName);
            _sqlCommand.Parameters.AddWithValue("@EmailAddress", freeRegistration.EmailAddress);
            _sqlCommand.Parameters.AddWithValue("@ContactNumber", freeRegistration.ContactNo);
            _sqlCommand.ExecuteNonQuery();
            return true;
        }
    }
}
