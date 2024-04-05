using DataAccessManager.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Operations
{
    public class FlatTypeMaster : IFlatTypeMaster
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public FlatTypeMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }
        public DataSet GetFlatTypeMasterList()
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLAT_TYPE_MASTER;           
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.FlatTypeMaster Save(Models.FlatTypeMaster flatTypeMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.ADD_FLAT_TYPE_MASTER;
            _sqlCommand.Parameters.AddWithValue("@FlatType", flatTypeMaster.FlatType);
            _sqlCommand.Parameters.AddWithValue("@StandardCharges", flatTypeMaster.StandardCharges);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatTypeMaster.SocietyID);
            _sqlCommand.ExecuteNonQuery();
            return flatTypeMaster;
        }
        public Models.FlatTypeMaster Update(Models.FlatTypeMaster flatTypeMaster)
        {
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = StoreProcedures.UPDATE_FLAT_TYPE_MASTER;
            _sqlCommand.Parameters.AddWithValue("@ID", flatTypeMaster.ID);
            _sqlCommand.Parameters.AddWithValue("@FlatType", flatTypeMaster.FlatType);
            _sqlCommand.Parameters.AddWithValue("@StandardCharges", flatTypeMaster.StandardCharges);
            _sqlCommand.Parameters.AddWithValue("@SocietyID", flatTypeMaster.SocietyID);
            _sqlCommand.ExecuteNonQuery();
            return flatTypeMaster;
        }
    }
}
