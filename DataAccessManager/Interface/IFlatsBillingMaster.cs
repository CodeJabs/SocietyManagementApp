using System.Data;

namespace DataAccessManager.Interface
{

    public interface IFlatsBillingMaster
  
    {
        DataSet GetFlatBillingDetails(int flatID);

        Models.FlatsBillingMaster Add(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);

        Models.FlatsBillingMaster Update(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster);
    }
}
