namespace Models
{
    public class SocietyMeetingRegister
    {
        private int _iD;
        private Society _society;
        private string _meetingDetails;
        private DateTime _scheduleDate;
        private string _meetingType;
        private string _meetingSubject;
        private string _meetingAgenda;
        private DateTime _requestedOn;
        public int ID { get { return _iD; } set { _iD = value; } }
        public Society Society { get { return _society; } set { _society = value; } }

        public string MeetingDetails { get { return _meetingDetails; } set { _meetingDetails = value; } }

        public DateTime ScheduleDate { get { return _scheduleDate; } set { _scheduleDate = value; } }

        public string MeetingType { get { return _meetingType; } set { _meetingType = value; } }

        public string MeetingSubject { get { return _meetingSubject; } set { _meetingSubject = value; } }
        public string MeetingAgenda { get { return _meetingAgenda; } set { _meetingAgenda = value; } }

        public DateTime RequestedOn { get { return _requestedOn; } set { _requestedOn = value; } }
    }
}
