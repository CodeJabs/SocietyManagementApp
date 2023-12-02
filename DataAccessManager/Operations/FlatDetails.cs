using DataAccessManager.Interface;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessManager.Operations
{
     
    public class FlatDetails : IFlatDetails
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public FlatDetails()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetFlatsList(Models.Society society)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_ALL_FLAT_LIST;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetFlatDetails(Models.Society society,Models.FlatDetails flatDetails)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.FlatDetails Save(Models.Society society, Models.FlatDetails flatDetails,Models.FlatOccupancyMaster flatOccupancyMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", flatDetails.FlatNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOwner", flatDetails.FlatOwner);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", flatDetails.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOccupanyID", flatOccupancyMaster.ID);
            return flatDetails;
        }

        public Models.FlatDetails Update(Models.Society society, Models.FlatDetails flatDetails, Models.FlatOccupancyMaster flatOccupancyMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", flatDetails.ID); 
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", flatDetails.FlatNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOwner", flatDetails.FlatOwner);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", flatDetails.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOccupanyID", flatOccupancyMaster.ID);
            return flatDetails;
        }
    }
}
