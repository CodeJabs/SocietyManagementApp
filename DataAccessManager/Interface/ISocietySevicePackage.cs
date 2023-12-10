using System.Data;

namespace DataAccessManager.Interface
{
<<<<<<< HEAD
    public interface ISocietySevicePackage
=======
    internal interface ISocietySevicePackage
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        public DataSet GetSocietyServicePackage();

        public DataSet GetSocietyServicePackageDetails(int packageID);

        public Models.SocietyServicePackage Save(Models.SocietyServicePackage societyServicePackage);

        public Models.SocietyServicePackage Update(Models.SocietyServicePackage societyServicePackage);
    }
}
