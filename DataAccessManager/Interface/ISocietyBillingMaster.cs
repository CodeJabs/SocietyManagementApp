using System.Data;

namespace DataAccessManager.Interface
{
    internal interface ISocietyBillingMaster
    {
        DataSet GetBillingMasterDetails(Models.Society society);

        Models.SocietyBillingMaster Add(Models.Society society, Models.SocietyBillingMaster societyBillingMaster);

        Models.SocietyBillingMaster Update(Models.Society society, Models.SocietyBillingMaster societyBillingMaster);
    }
}
