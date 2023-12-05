using Models;
using System.Data;

namespace DataAccessManager.Interface
{
    public interface ISocietyComitteeMembers
    {
        DataSet GetCommitteeMembers(UserMaster userMaster);

        Models.SocietyComitteeMembers Add(Models.SocietyComitteeMembers societyComitteeMembers);

        Models.SocietyComitteeMembers Update(Models.SocietyComitteeMembers societyComitteeMembers);
    }
}
