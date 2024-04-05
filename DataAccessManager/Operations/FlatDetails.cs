using DataAccessManager.Interface;
using Models;
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

        public DataSet GetFlatsList(int SocietyID)
        {
            //_sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_ALL_FLAT_LIST;            
            _sqlCommand.Parameters.AddWithValue("@SocietyID", SocietyID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetFlatDetails(int societyID, int flatID)
        {
            //_sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyID);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.FlatDetails Save(Models.Society society, Models.FlatDetails flatDetails,Models.FlatOccupancyMaster flatOccupancyMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", flatDetails.FlatNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOwner", flatDetails.FlatOwner);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", flatDetails.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOccupanyID", flatOccupancyMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatTypeID", flatDetails.FlatTypeId);
            _sqlCommand.ExecuteNonQuery();
            return flatDetails;
        }

        public Models.FlatDetails Update(Models.Society society, Models.FlatDetails flatDetails, Models.FlatOccupancyMaster flatOccupancyMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.UPDATE_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", flatDetails.ID); 
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatNo", flatDetails.FlatNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOwner", flatDetails.FlatOwner);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", flatDetails.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FlatOccupanyID", flatOccupancyMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatTypeID", flatDetails.FlatTypeId);
            _sqlCommand.ExecuteNonQuery();
            return flatDetails;
        }
    }
}
