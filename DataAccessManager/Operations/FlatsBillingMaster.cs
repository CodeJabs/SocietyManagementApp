using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using Models;
using DataAccessManager.Interface;
using System;

namespace DataAccessManager.Operations
{
<<<<<<< HEAD
    public class FlatsBillingMaster : IFlatsBillingMaster
=======
    internal class FlatsBillingMaster : IFlatsBillingMaster
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
    {
        private SqlConnection _sqlConnection { get; set; }
        private ConnectionInstance _connectionInstance { get; set; }
        private SqlCommand _sqlCommand { get; set; }
        private SqlDataAdapter _sqlDataAdapter { get; set; }
        private DataSet _dataSet { get; set; }

        private DataBaseHelpers _dataBaseHelper = null;
        public FlatsBillingMaster()
        {
            _dataBaseHelper = new DataBaseHelpers();
            _connectionInstance = new ConnectionInstance(_dataBaseHelper.GetConnectionString());
            _sqlConnection = _connectionInstance.GetSqlConnectionInstances().Item1;
            _sqlCommand = _connectionInstance.GetSqlConnectionInstances().Item2;
            _sqlDataAdapter = _connectionInstance.GetSqlConnectionInstances().Item3;
            _dataSet = new DataSet();
        }

        public DataSet GetFlatBillingDetails(Models.FlatDetails flatDetails)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.GET_FLATS_BILLING;
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);           
            _sqlDataAdapter.SelectCommand = _sqlCommand;
            _sqlDataAdapter.Fill(_dataSet);
            return _dataSet;
        }

        public Models.FlatsBillingMaster Add(Models.FlatDetails flatDetails,Models.FlatsBillingMaster flatsBillingMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@Type", flatsBillingMaster.Type);
            _sqlCommand.Parameters.AddWithValue("@StandardPricing", flatsBillingMaster.StandardPricing);
            _sqlCommand.Parameters.AddWithValue("@SGST", flatsBillingMaster.SGST);
            _sqlCommand.Parameters.AddWithValue("@CGST", flatsBillingMaster.CGST);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID) ;
            _sqlCommand.Parameters.AddWithValue("@Penalty", flatsBillingMaster.Penalty);
            _sqlCommand.Parameters.AddWithValue("@InterestCharges", flatsBillingMaster.InterestCharges);
            _sqlCommand.Parameters.AddWithValue("@FlatTransferCharges", flatsBillingMaster.FlatTransferCharges);
            _sqlCommand.Parameters.AddWithValue("@ParkingCharges", flatsBillingMaster.ParkingCharges);
            _sqlCommand.Parameters.AddWithValue("@NONOccupancyCharges", flatsBillingMaster.NonOccupancyCharges);
            _sqlCommand.Parameters.AddWithValue("@ServiceCharges", flatsBillingMaster.ServiceCharges);
            _sqlCommand.Parameters.AddWithValue("@ElectricityCharges", flatsBillingMaster.ElectricityCharges);
            _sqlCommand.Parameters.AddWithValue("@PropertyTax", flatsBillingMaster.PropertyTax);
            _sqlCommand.ExecuteNonQuery();
            return flatsBillingMaster;
        }

        public Models.FlatsBillingMaster Update(Models.FlatDetails flatDetails, Models.FlatsBillingMaster flatsBillingMaster)
        {
            _sqlDataAdapter.SelectCommand.Connection = _sqlConnection;
            _sqlDataAdapter.SelectCommand.CommandText = StoreProcedures.ADD_NEW_FLAT_DETAILS;
            _sqlCommand.Parameters.AddWithValue("@ID", flatsBillingMaster.Id); 
            _sqlCommand.Parameters.AddWithValue("@Type", flatsBillingMaster.Type);
            _sqlCommand.Parameters.AddWithValue("@StandardPricing", flatsBillingMaster.StandardPricing);
            _sqlCommand.Parameters.AddWithValue("@SGST", flatsBillingMaster.SGST);
            _sqlCommand.Parameters.AddWithValue("@CGST", flatsBillingMaster.CGST);
            _sqlCommand.Parameters.AddWithValue("@FlatID", flatDetails.ID);
            _sqlCommand.Parameters.AddWithValue("@Penalty", flatsBillingMaster.Penalty);
            _sqlCommand.Parameters.AddWithValue("@InterestCharges", flatsBillingMaster.InterestCharges);
            _sqlCommand.Parameters.AddWithValue("@FlatTransferCharges", flatsBillingMaster.FlatTransferCharges);
            _sqlCommand.Parameters.AddWithValue("@ParkingCharges", flatsBillingMaster.ParkingCharges);
            _sqlCommand.Parameters.AddWithValue("@NONOccupancyCharges", flatsBillingMaster.NonOccupancyCharges);
            _sqlCommand.Parameters.AddWithValue("@ServiceCharges", flatsBillingMaster.ServiceCharges);
            _sqlCommand.Parameters.AddWithValue("@ElectricityCharges", flatsBillingMaster.ElectricityCharges);
            _sqlCommand.Parameters.AddWithValue("@PropertyTax", flatsBillingMaster.PropertyTax);
            _sqlCommand.ExecuteNonQuery();
            return flatsBillingMaster;
        }


    }
}
