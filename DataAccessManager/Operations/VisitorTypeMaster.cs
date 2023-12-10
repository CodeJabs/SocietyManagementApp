using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
 
    public class VisitorTypeMaster : IVisitorTypeMaster
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public VisitorTypeMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetVisitorTypesList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_VISITOR_TYPE;
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.VisitorTypeMaster Add(Models.VisitorTypeMaster visitorTypeMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_VISITOR_TYPE;
            _sqlCommand.Parameters.AddWithValue("@visitorType", visitorTypeMaster.Type);
            _sqlCommand.ExecuteNonQuery();
            return visitorTypeMaster;
        }

        public Models.VisitorTypeMaster Update(Models.VisitorTypeMaster visitorTypeMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_VISITOR_TYPE;
            _sqlCommand.Parameters.AddWithValue("@Id", visitorTypeMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@visitorType", visitorTypeMaster.Type);
            _sqlCommand.ExecuteNonQuery();
            return visitorTypeMaster;
        }
    }
}
