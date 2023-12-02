using DataAccessManager.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessManager.Operations
{
   public class Society : ISociety
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public Society()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();

        }

        public DataSet GetSocieties()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_LIST;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetSocietyDetails(int SocietyID)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.GET_SOCIETY_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", SocietyID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.Society Save(Models.Society society)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_NEW_SOCIETY;
            _sqlCommand.Parameters.AddWithValue("@Name", society.Name);
            _sqlCommand.Parameters.AddWithValue("@Abbreviation", society.Abbreviation);
            _sqlCommand.Parameters.AddWithValue("@Address", society.Address);
            _sqlCommand.Parameters.AddWithValue("@TelephoneNumber", society.TelephoneNumber);
            _sqlCommand.Parameters.AddWithValue("@SocietyPackageId", society.societyServicePackage.ID);
            _sqlCommand.ExecuteNonQuery();
            return society;
        }
    }
}
