using System.Data;

namespace DataAccessManager.Interface
{
    public interface IPaymentMaster
    {
        DataSet GetPaymentMasterList();
        Models.PaymentMaster Add(Models.PaymentMaster paymentMaster);
        Models.PaymentMaster Update(Models.PaymentMaster paymentMaster);
    }
}
