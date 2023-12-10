using System.Data;

namespace DataAccessManager.Interface
{

    public interface IFlatsBillingMaster
  
    {
        DataSet GetFlatBillingDetails(Models.FlatDetails flatDetails);

        Models.FlatsBillingMaster Add(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);

        Models.FlatsBillingMaster Update(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);
    }
}
