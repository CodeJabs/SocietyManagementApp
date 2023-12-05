using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class SocietyMemberMaster : ISocietyMemberMaster
    {

        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public SocietyMemberMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }


        public DataSet GetSocietyMemberMasterList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_MEMBER_MASTER;            
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyMemberMaster Add(Models.SocietyMemberMaster societyMemberMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_MEMBER_MASTER;
            _sqlCommand.Parameters.AddWithValue("@Type", societyMemberMaster.Type);
            _sqlCommand.ExecuteNonQuery();
            return societyMemberMaster;        
        }

        public Models.SocietyMemberMaster Update(Models.SocietyMemberMaster societyMemberMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_MEMBER_MASTER;
            _sqlCommand.Parameters.AddWithValue("@ID", societyMemberMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@Type", societyMemberMaster.Type);
            _sqlCommand.ExecuteNonQuery();
            return societyMemberMaster;
        }
    }
}
