using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class FlatPayments : IFlatPayments
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public FlatPayments()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetFlatPaymentList(Models.FlatDetails flatDetails)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_PAYMENT_LIST;
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetFlatPaymentDetails(Models.FlatDetails flatDetails,Models.FlatPayments flatPayments)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_PAYMENT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", flatPayments.ID);
            _sqlCommand.Parameters.AddWithValue("@InvoiceID", flatPayments.InvoiceID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.FlatPayments Add(Models.FlatPayments flatPayments, Models.FlatDetails flatDetails,Models.PaymentMaster paymentMaster,Models.UserMaster userMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@InvoiceID", flatPayments.InvoiceID);
            _sqlCommand.Parameters.AddWithValue("@FromDate", flatPayments.FromDate);
            _sqlCommand.Parameters.AddWithValue("@ToDate", flatPayments.ToDate);
            _sqlCommand.Parameters.AddWithValue("@PaymentType", paymentMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@UserID", userMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@FlatId", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatDetails.Society.ID);
            _sqlCommand.ExecuteNonQuery();
            return flatPayments;
        }

        public Models.FlatPayments Update(Models.FlatPayments flatPayments, Models.FlatDetails flatDetails, Models.PaymentMaster paymentMaster, Models.UserMaster userMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", flatPayments.ID); 
            _sqlCommand.Parameters.AddWithValue("@InvoiceID", flatPayments.InvoiceID);
            _sqlCommand.Parameters.AddWithValue("@FromDate", flatPayments.FromDate);
            _sqlCommand.Parameters.AddWithValue("@ToDate", flatPayments.ToDate);
            _sqlCommand.Parameters.AddWithValue("@PaymentType", paymentMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@UserID", userMaster.UserID);
            _sqlCommand.Parameters.AddWithValue("@FlatId", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatDetails.Society.ID);
            _sqlCommand.ExecuteNonQuery();
            return flatPayments;
        }
    }
}
