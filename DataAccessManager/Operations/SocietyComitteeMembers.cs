using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;


namespace DataAccessManager.Operations
{
    public class SocietyComitteeMembers : ISocietyComitteeMembers
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public SocietyComitteeMembers()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetCommitteeMembers(Models.UserMaster userMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_COMMITTEE_MEMBERS;
            _sqlCommand.Parameters.AddWithValue("@UserID", userMaster.UserID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyComitteeMembers Add(Models.SocietyComitteeMembers societyComitteeMembers)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIETY_COMMITTEE_MEMBERS;
            _sqlCommand.Parameters.AddWithValue("@UserID", societyComitteeMembers.UserMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", societyComitteeMembers.FlatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@MemberTypeID", societyComitteeMembers.SocietyMemberMaster.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyComitteeMembers;
        }

        public Models.SocietyComitteeMembers Update(Models.SocietyComitteeMembers societyComitteeMembers)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_SOCIETY_COMMITTEE_MEMBERS;
            _sqlCommand.Parameters.AddWithValue("@ID", societyComitteeMembers.ID);
            _sqlCommand.Parameters.AddWithValue("@UserID", societyComitteeMembers.UserMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", societyComitteeMembers.FlatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@MemberTypeID", societyComitteeMembers.SocietyMemberMaster.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyComitteeMembers;
        }
    }
}
