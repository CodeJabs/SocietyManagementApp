
using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface IVisitorTypeMaster
=======
    internal interface IVisitorTypeMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015

    {
        DataSet GetVisitorTypesList();

        Models.VisitorTypeMaster Add(Models.VisitorTypeMaster visitorTypeMaster);

        Models.VisitorTypeMaster Update(Models.VisitorTypeMaster visitorTypeMaster);
    }
}
