

using System.Data;

namespace DataAccessManager.Interface
{
    public interface IUserMaster
    {
        DataSet GetUserMasterList(Models.Society society, int UserID);

        DataSet GetUserMasterDetails(Models.Society society, int UserID);


        DataSet GetAllUserMasterDetails(Models.Society society, int UserID);


        Models.UserMaster Add(Models.UserMaster userMaster);

        Models.UserMaster Update(Models.UserMaster userMaster);
    }
}
