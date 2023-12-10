using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
<<<<<<< HEAD
    public class UserMaster : IUserMaster
=======
    internal class UserMaster : IUserMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public UserMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetUserMasterList(Models.Society society, int UserID)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_USER_LIST;
            _sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetUserMasterDetails(Models.Society society, int UserID)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_USER_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetAllUserMasterDetails(Models.Society society, int UserID)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_USER_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@UserID", UserID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.UserMaster Add(Models.UserMaster userMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_USERS_MASTER;
            _sqlCommand.Parameters.AddWithValue("@FirstName", userMaster.FirstName);
            _sqlCommand.Parameters.AddWithValue("@LastName", userMaster.LastName);
            _sqlCommand.Parameters.AddWithValue("@UserName", userMaster.UserName);
            _sqlCommand.Parameters.AddWithValue("@Password", userMaster.Password);
            _sqlCommand.Parameters.AddWithValue("@UserRoleId", userMaster.RoleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@MobileNo", userMaster.MobileNo);
            _sqlCommand.Parameters.AddWithValue("@EmailAddress", userMaster.EmailId);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", userMaster.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@UserLocked", userMaster.IsUserLocked);
            _sqlCommand.Parameters.AddWithValue("@UserDeleted", userMaster.IsUserDeleted);
            _sqlCommand.Parameters.AddWithValue("@CreatedBy", userMaster.UserID);
            _sqlCommand.ExecuteNonQuery();
            return userMaster;
        }

        public Models.UserMaster Update(Models.UserMaster userMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_USERS_MASTER;
            _sqlCommand.Parameters.AddWithValue("@UserID", userMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@FirstName", userMaster.FirstName);
            _sqlCommand.Parameters.AddWithValue("@LastName", userMaster.LastName);
            _sqlCommand.Parameters.AddWithValue("@UserName", userMaster.UserName);
            _sqlCommand.Parameters.AddWithValue("@Password", userMaster.Password);
            _sqlCommand.Parameters.AddWithValue("@UserRoleId", userMaster.RoleMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@MobileNo", userMaster.MobileNo);
            _sqlCommand.Parameters.AddWithValue("@EmailAddress", userMaster.EmailId);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", userMaster.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@UserLocked", userMaster.IsUserLocked);
            _sqlCommand.Parameters.AddWithValue("@UserDeleted", userMaster.IsUserDeleted);

            _sqlCommand.ExecuteNonQuery();
            return userMaster;
        }
    }
}
