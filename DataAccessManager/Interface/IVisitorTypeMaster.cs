
using System.Data;

namespace DataAccessManager.Interface
{
    internal interface IVisitorTypeMaster

    {
        DataSet GetVisitorTypesList();

        Models.VisitorTypeMaster Add(Models.VisitorTypeMaster visitorTypeMaster);

        Models.VisitorTypeMaster Update(Models.VisitorTypeMaster visitorTypeMaster);
    }
}
