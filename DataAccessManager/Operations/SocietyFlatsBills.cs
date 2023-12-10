using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
 
    public class SocietyFlatsBills : ISocietyFlatsBills 
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public SocietyFlatsBills()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetFlatsForSocietyBills(Models.Society society,Models.FlatDetails flatDetails)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_FLATS_BILLS_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@BillingType", flatDetails.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyFlatsBills Add(Models.Society society, Models.FlatDetails flatDetails,Models.SocietyFlatsBills societyFlatsBills)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIETY_FLATS_BILLS_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@BillingType", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@TotalAmount", societyFlatsBills.TotalAmount);
            _sqlCommand.Parameters.AddWithValue("@BillIssueDate", societyFlatsBills.BillIssueDate);
            _sqlCommand.Parameters.AddWithValue("@BillDueDate", societyFlatsBills.BillDueDate);
            _sqlCommand.Parameters.AddWithValue("@Remarks", societyFlatsBills.Remarks);
            _sqlCommand.ExecuteNonQuery();
            
            return societyFlatsBills;
        }

        public Models.SocietyFlatsBills Update(Models.Society society, Models.FlatDetails flatDetails, Models.SocietyFlatsBills societyFlatsBills)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_SOCIETY_FLATS_BILLS_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", societyFlatsBills.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@BillingType", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@TotalAmount", societyFlatsBills.TotalAmount);
            _sqlCommand.Parameters.AddWithValue("@BillIssueDate", societyFlatsBills.BillIssueDate);
            _sqlCommand.Parameters.AddWithValue("@BillDueDate", societyFlatsBills.BillDueDate);
            _sqlCommand.Parameters.AddWithValue("@Remarks", societyFlatsBills.Remarks);
            _sqlCommand.ExecuteNonQuery();

            return societyFlatsBills;
        }


    }
}
