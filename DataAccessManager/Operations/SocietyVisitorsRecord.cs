using DataAccessManager.Interface;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessManager.Operations
{
    public class SocietyVisitorsRecord : ISocietyVisitorsRecord
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;

        public SocietyVisitorsRecord()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetVisitorRecordByDateWise(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIEY_VISITOR_DETAILS_DATEWISE;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyVisitorsRecord.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatId", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@EntryTime", entryDateTime);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyVisitorsRecord Add(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIETY_VISITORS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyVisitorsRecord.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@VisitorType", societyVisitorsRecord.VisitorTypeMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@Name", societyVisitorsRecord.Name);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", societyVisitorsRecord.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FromLocation", societyVisitorsRecord.FromLocation);
            _sqlCommand.Parameters.AddWithValue("@EntryTime", societyVisitorsRecord.EntryTime);
            _sqlCommand.Parameters.AddWithValue("@FlatId", flatDetails.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyVisitorsRecord;
        }

        public Models.SocietyVisitorsRecord Update(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.UPDATE_SOCIETY_VISITORS;
            _sqlCommand.Parameters.AddWithValue("@ID", societyVisitorsRecord.ID); 
            _sqlCommand.Parameters.AddWithValue("@SocietyID", societyVisitorsRecord.Society.ID);
            _sqlCommand.Parameters.AddWithValue("@VisitorType", societyVisitorsRecord.VisitorTypeMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@Name", societyVisitorsRecord.Name);
            _sqlCommand.Parameters.AddWithValue("@ContactNo", societyVisitorsRecord.ContactNo);
            _sqlCommand.Parameters.AddWithValue("@FromLocation", societyVisitorsRecord.FromLocation);
            _sqlCommand.Parameters.AddWithValue("@EntryTime", societyVisitorsRecord.EntryTime);
            _sqlCommand.Parameters.AddWithValue("@FlatId", flatDetails.ID);
            _sqlCommand.ExecuteNonQuery();
            return societyVisitorsRecord;
        }
    }
}
