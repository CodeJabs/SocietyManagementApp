using System.Data;

namespace DataAccessManager.Interface
{

    public interface ISocietySevicePackage
    {
        public DataSet GetSocietyServicePackage();

        public DataSet GetSocietyServicePackageDetails(int packageID);

        public Models.SocietyServicePackage Save(Models.SocietyServicePackage societyServicePackage);

        public Models.SocietyServicePackage Update(Models.SocietyServicePackage societyServicePackage);
    }
}
