using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
<<<<<<< HEAD
    public class SocietyNominationRegister : ISocietyNominationRegister
=======
    internal class SocietyNominationRegister : ISocietyNominationRegister
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public SocietyNominationRegister()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public Models.SocietyNominationRegister Add(Models.SocietyNominationRegister societyNominationRegister)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIEY_NOMINATION_REGISTER;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyNominationRegister.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", societyNominationRegister.FlatDetails.FlatNo);
            _sqlCommand.ExecuteNonQuery();
            return societyNominationRegister;
        }

        public Models.SocietyNominationRegister Update(Models.SocietyNominationRegister societyNominationRegister)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIEY_NOMINATION_REGISTER;
            _sqlCommand.Parameters.AddWithValue("@ID", societyNominationRegister.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyNominationRegister.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", societyNominationRegister.FlatDetails.FlatNo);
            _sqlCommand.ExecuteNonQuery();
            return societyNominationRegister;
        }






    }
}
