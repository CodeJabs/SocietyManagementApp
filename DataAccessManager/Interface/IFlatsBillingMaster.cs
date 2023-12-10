using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface IFlatsBillingMaster
=======
    internal interface IFlatsBillingMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        DataSet GetFlatBillingDetails(Models.FlatDetails flatDetails);

        Models.FlatsBillingMaster Add(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);

        Models.FlatsBillingMaster Update(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);
    }
}
