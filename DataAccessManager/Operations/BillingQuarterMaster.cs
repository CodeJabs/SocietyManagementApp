using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class BillingQuarterMaster : IBillingQuarterMaster
    {

        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public BillingQuarterMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetQuarterList()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_BILLING_QUARTER_LIST;            
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.BillingQuaterMaster Save(Models.BillingQuaterMaster billingQuaterMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_BILLING_QUARTER;
            _sqlCommand.Parameters.AddWithValue("@QuarterType", billingQuaterMaster.QuaterType);            
            _sqlCommand.ExecuteNonQuery();
            return billingQuaterMaster;
        }

        public Models.BillingQuaterMaster Update(Models.BillingQuaterMaster billingQuaterMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.UPDATE_BILLING_QUARTER;
            _sqlCommand.Parameters.AddWithValue("@Id", billingQuaterMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@QuarterType", billingQuaterMaster.QuaterType);
            _sqlCommand.ExecuteNonQuery();
            return billingQuaterMaster;
        }
    }
}
