using System.Data.SqlClient;
using System.Data;

namespace DataAccessManager.Operations
{
    internal class SocietyBillingMaster
    {

        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public SocietyBillingMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetBillingMasterDetails(Models.Society society)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.GET_SOCIETY_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }


        public Models.SocietyBillingMaster Add(Models.Society society,Models.SocietyBillingMaster societyBillingMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIEY_BILLING_MASTER;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyPackageID", society.societyServicePackage.ID);
            _sqlCommand.Parameters.AddWithValue("@StandardPricing", societyBillingMaster.StandardPricing);
            _sqlCommand.Parameters.AddWithValue("@SGGST", societyBillingMaster.SGST);
            _sqlCommand.Parameters.AddWithValue("@CGST", societyBillingMaster.CGST);
            _sqlCommand.Parameters.AddWithValue("@TotalPrice", societyBillingMaster.TotalPrice);
            _sqlCommand.Parameters.AddWithValue("@Electricity", societyBillingMaster.Electricity);
            _sqlCommand.Parameters.AddWithValue("@Water", societyBillingMaster.Water);
            _sqlCommand.Parameters.AddWithValue("@Property", societyBillingMaster.Property);
            _sqlCommand.Parameters.AddWithValue("@OtherExpenses", societyBillingMaster.OtherExpenses);
            _sqlCommand.ExecuteNonQuery();
            return societyBillingMaster;
        }


        public Models.SocietyBillingMaster Update(Models.Society society, Models.SocietyBillingMaster societyBillingMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_SOCIEY_BILLING_MASTER;
            _sqlCommand.Parameters.AddWithValue("@ID", societyBillingMaster.Id);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyPackageID", society.societyServicePackage.ID);
            _sqlCommand.Parameters.AddWithValue("@StandardPricing", societyBillingMaster.StandardPricing);
            _sqlCommand.Parameters.AddWithValue("@SGGST", societyBillingMaster.SGST);
            _sqlCommand.Parameters.AddWithValue("@CGST", societyBillingMaster.CGST);
            _sqlCommand.Parameters.AddWithValue("@TotalPrice", societyBillingMaster.TotalPrice);
            _sqlCommand.Parameters.AddWithValue("@Electricity", societyBillingMaster.Electricity);
            _sqlCommand.Parameters.AddWithValue("@Water", societyBillingMaster.Water);
            _sqlCommand.Parameters.AddWithValue("@Property", societyBillingMaster.Property);
            _sqlCommand.Parameters.AddWithValue("@OtherExpenses", societyBillingMaster.OtherExpenses);
            _sqlCommand.ExecuteNonQuery();
            return societyBillingMaster;
        }
    }
}
