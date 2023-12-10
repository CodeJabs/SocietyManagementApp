using Models;
using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface ISocietyComitteeMembers
=======
    internal interface ISocietyComitteeMembers
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        DataSet GetCommitteeMembers(UserMaster userMaster);

        Models.SocietyComitteeMembers Add(Models.SocietyComitteeMembers societyComitteeMembers);

        Models.SocietyComitteeMembers Update(Models.SocietyComitteeMembers societyComitteeMembers);
    }
}
