using System.Data.SqlClient;
using System.Data;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class SocietyMeetingRegister : ISocietyMeetingRegister
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public SocietyMeetingRegister()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetSocietyMeetings(Models.Society society)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_MEETINGS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.SocietyMeetingRegister Add(Models.SocietyMeetingRegister societyMeetingRegister,Models.Society society)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIETY_MEETINGS;
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@MeetingDetails", societyMeetingRegister.MeetingDetails);
            _sqlCommand.Parameters.AddWithValue("@ScheduleDate", societyMeetingRegister.ScheduleDate);
            _sqlCommand.Parameters.AddWithValue("@MeetingType", societyMeetingRegister.MeetingDetails);
            _sqlCommand.Parameters.AddWithValue("@MeetingSubject", societyMeetingRegister.MeetingSubject);
            _sqlCommand.Parameters.AddWithValue("@MeetingAgenda", societyMeetingRegister.MeetingAgenda);
            _sqlCommand.ExecuteNonQuery();

            return societyMeetingRegister;
        }

        public Models.SocietyMeetingRegister Update(Models.SocietyMeetingRegister societyMeetingRegister, Models.Society society)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_SOCIETY_MEETINGS;
            _sqlCommand.Parameters.AddWithValue("@ID", societyMeetingRegister.ID);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", society.ID);
            _sqlCommand.Parameters.AddWithValue("@MeetingDetails", societyMeetingRegister.MeetingDetails);
            _sqlCommand.Parameters.AddWithValue("@ScheduleDate", societyMeetingRegister.ScheduleDate);
            _sqlCommand.Parameters.AddWithValue("@MeetingType", societyMeetingRegister.MeetingDetails);
            _sqlCommand.Parameters.AddWithValue("@MeetingSubject", societyMeetingRegister.MeetingSubject);
            _sqlCommand.Parameters.AddWithValue("@MeetingAgenda", societyMeetingRegister.MeetingAgenda);
            _sqlCommand.ExecuteNonQuery();

            return societyMeetingRegister;
        }






    }
}
