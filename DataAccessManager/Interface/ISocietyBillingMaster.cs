using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface ISocietyBillingMaster
=======
    internal interface ISocietyBillingMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        DataSet GetBillingMasterDetails(Models.Society society);

        Models.SocietyBillingMaster Add(Models.Society society, Models.SocietyBillingMaster societyBillingMaster);

        Models.SocietyBillingMaster Update(Models.Society society, Models.SocietyBillingMaster societyBillingMaster);
    }
}
