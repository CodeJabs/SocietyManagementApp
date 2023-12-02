using System.Data;

namespace DataAccessManager.Interface
{
    public interface IFreeRegistration
    {
        DataSet GetFreeRegistration();

        bool Add(Models.FreeRegistration freeRegistration);
    }
}
