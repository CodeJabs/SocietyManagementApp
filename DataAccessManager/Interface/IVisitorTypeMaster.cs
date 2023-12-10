
using System.Data;

namespace DataAccessManager.Interface
{

    public interface IVisitorTypeMaster
    {
        DataSet GetVisitorTypesList();

        Models.VisitorTypeMaster Add(Models.VisitorTypeMaster visitorTypeMaster);

        Models.VisitorTypeMaster Update(Models.VisitorTypeMaster visitorTypeMaster);
    }
}
