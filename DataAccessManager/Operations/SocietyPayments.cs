using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class SocietyPayments : ISocietyPayments
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public SocietyPayments()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }


        public DataSet GetSocietyPayments(Models.Society society)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIEY_PAYMENTS_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyPayments Add(Models.SocietyPayments societyPayments)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIEY_PAYMENTS;
            _sqlCommand.Parameters.AddWithValue("@InvoiceID", societyPayments.InvoiceID);
            _sqlCommand.Parameters.AddWithValue("@FromDate", societyPayments.FromDate);
            _sqlCommand.Parameters.AddWithValue("@ToDate", societyPayments.ToDate);
            _sqlCommand.Parameters.AddWithValue("@PaymentId", societyPayments.PaymentMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@UserId", societyPayments.UserMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyPayments.Society.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyPayments;
        }

        public Models.SocietyPayments Update(Models.SocietyPayments societyPayments)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIEY_PAYMENTS;
            _sqlCommand.Parameters.AddWithValue("@ID", societyPayments.ID);
            _sqlCommand.Parameters.AddWithValue("@InvoiceID", societyPayments.InvoiceID);
            _sqlCommand.Parameters.AddWithValue("@FromDate", societyPayments.FromDate);
            _sqlCommand.Parameters.AddWithValue("@ToDate", societyPayments.ToDate);
            _sqlCommand.Parameters.AddWithValue("@PaymentId", societyPayments.PaymentMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@UserId", societyPayments.UserMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyPayments.Society.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyPayments;
        }
    }
}
