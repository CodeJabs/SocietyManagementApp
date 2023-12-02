using System.Data;


namespace DataAccessManager.Interface
{
    public interface ISocietyPayments
    {
        DataSet GetSocietyPayments(Models.Society society);

        Models.SocietyPayments Add(Models.SocietyPayments societyPayments);

        Models.SocietyPayments Update(Models.SocietyPayments societyPayments);


    }
}
