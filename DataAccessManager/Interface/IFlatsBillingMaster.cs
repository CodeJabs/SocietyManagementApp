using System.Data;

namespace DataAccessManager.Interface
{
    internal interface IFlatsBillingMaster
    {
        DataSet GetFlatBillingDetails(Models.FlatDetails flatDetails);

        Models.FlatsBillingMaster Add(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);

        Models.FlatsBillingMaster Update(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);
    }
}
