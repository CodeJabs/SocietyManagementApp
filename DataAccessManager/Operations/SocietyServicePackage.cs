using System.Data.SqlClient;
using System.Data;
using Models;
using DataAccessManager.Interface;

namespace DataAccessManager.Operations
{
    public class SocietyServicePackage : ISocietySevicePackage
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public SocietyServicePackage()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetSocietyServicePackage()
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_SOCIETY_SERVICE_PACKAGES;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public DataSet GetSocietyServicePackageDetails(int packageID)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.GET_SOCIETY_SERVICE_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@servicePackageID", packageID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }


        public Models.SocietyServicePackage Save(Models.SocietyServicePackage societyServicePackage)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_NEW_SERVICE_PACKAGE;
            _sqlCommand.Parameters.AddWithValue("@Type", societyServicePackage.Type);
            _sqlCommand.Parameters.AddWithValue("@PackagePrice", societyServicePackage.PackagePrice);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return societyServicePackage;
        }

        public Models.SocietyServicePackage Update(Models.SocietyServicePackage societyServicePackage)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.GET_SOCIETY_SERVICE_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@servicePackageID", societyServicePackage.ID);
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return societyServicePackage;
        }


    }
}
