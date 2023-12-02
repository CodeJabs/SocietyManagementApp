
using System.Data;

namespace DataAccessManager.Interface
{
    public interface IRoleMaster
    {
        DataSet GetRoleMasterList();

        Models.RoleMaster Add(Models.RoleMaster roleMaster);


        Models.RoleMaster Update(Models.RoleMaster roleMaster);
    }
}
