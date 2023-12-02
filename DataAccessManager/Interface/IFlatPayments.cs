using Models;
using System.Data;

namespace DataAccessManager.Interface
{
    public interface IFlatPayments
    {
        DataSet GetFlatPaymentList(Models.FlatDetails flatDetails);
        DataSet GetFlatPaymentDetails(Models.FlatDetails flatDetails, Models.FlatPayments flatPayments);
        Models.FlatPayments Add(Models.FlatPayments flatPayments, Models.FlatDetails flatDetails, Models.PaymentMaster paymentMaster, Models.UserMaster userMaster);
        Models.FlatPayments Update(Models.FlatPayments flatPayments, Models.FlatDetails flatDetails, Models.PaymentMaster paymentMaster, Models.UserMaster userMaster);
    }
}
