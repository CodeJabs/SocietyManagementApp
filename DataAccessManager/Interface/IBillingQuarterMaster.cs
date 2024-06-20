using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Interface
{
    public interface IBillingQuarterMaster
    {
        DataSet GetQuarterList();

        Models.BillingQuaterMaster Save(Models.BillingQuaterMaster billingQuaterMaster);

        Models.BillingQuaterMaster Update(Models.BillingQuaterMaster billingQuaterMaster);
    }
}
