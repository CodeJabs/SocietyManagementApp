using System.Data;

namespace DataAccessManager.Interface
{
    public interface ISocietyMeetingRegister
    {
        DataSet GetSocietyMeetings(Models.Society society);

        Models.SocietyMeetingRegister Add(Models.SocietyMeetingRegister societyMeetingRegister, Models.Society society);

        Models.SocietyMeetingRegister Update(Models.SocietyMeetingRegister societyMeetingRegister, Models.Society society);
    }
}
