using System.Data;

namespace DataAccessManager.Interface
{
    public interface ISocietyMemberMaster
    {
        DataSet GetSocietyMemberMasterList();

        Models.SocietyMemberMaster Add(Models.SocietyMemberMaster societyMemberMaster);

        Models.SocietyMemberMaster Update(Models.SocietyMemberMaster societyMemberMaster);

    }
}
