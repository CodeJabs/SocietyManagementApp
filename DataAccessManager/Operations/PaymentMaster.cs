using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class PaymentMaster : IPaymentMaster
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public PaymentMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetPaymentMasterList()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_PAYMENT_MASTER;
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.PaymentMaster Add(Models.PaymentMaster paymentMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_PAYMENT_MASTER;
            _sqlCommand.Parameters.AddWithValue("@Type", paymentMaster.paymentType);
            _sqlCommand.ExecuteNonQuery();
            return paymentMaster;
        }

        public Models.PaymentMaster Update(Models.PaymentMaster paymentMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_PAYMENT_MASTER;
            _sqlCommand.Parameters.AddWithValue("@ID", paymentMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@Type", paymentMaster.paymentType);
            _sqlCommand.ExecuteNonQuery();
            return paymentMaster;
        }
    }
}
