using System.Xml.Serialization;

namespace DataAccessManager
{
    public class StoreProcedures
    {
        public const string SCHEMA_NAME = "dbo.";
        public const string ADD_FLAT_OCCUPANCY = SCHEMA_NAME + "AddFlatOccupany";
        public const string ADD_NEW_SOCIETY = SCHEMA_NAME + "AddNewSociety";
        public const string ADD_ROLES = SCHEMA_NAME + "AddRoles";
        public const string GET_FLAT_OCCUPANCY_LIST = SCHEMA_NAME + "GetFlatOccupancyList";
        public const string GET_ROLES_LIST = SCHEMA_NAME + "GetRolesList";
        public const string GET_SOCIETY_DETAILS = SCHEMA_NAME + "GetSocietyDetails";
        public const string GET_SOCIETY_LIST = SCHEMA_NAME + "GetSocietyList";        
        public const string ADD_NEW_FLAT_DETAILS = SCHEMA_NAME + "Proc_AddNewFlatDetails";
        public const string GET_ALL_FLAT_LIST = SCHEMA_NAME + "Proc_GetAllFlatsList";
        public const string GET_FLAT_DETAILS = SCHEMA_NAME + "Proc_GetFlatDetails";
        public const string GET_OCCUPANCY_LIST = SCHEMA_NAME + "Proc_GetOccupancyList";
        public const string UPDATE_FLAT_DETAILS = SCHEMA_NAME + "Proc_UpdateFlatDetails";
        public const string UPDATEW_FLAT_DETAILS = SCHEMA_NAME + "Proc_UpdatewFlatDetails";
        public const string GET_SOCIETY_SERVICE_PACKAGES = SCHEMA_NAME + "Proc_GetSocietyServicePackages";
        public const string GET_SOCIETY_SERVICE_DETAILS = SCHEMA_NAME + "Proc_GetSocietyServicePackageDetail";
        public const string ADD_NEW_SERVICE_PACKAGE = SCHEMA_NAME + "Proc_AddSocietyServicePackage";
        public const string ADD_NEW_VEHICLE_TYPE = SCHEMA_NAME + "Proc_AddVehicleMaster";
        public const string UPDATE_VEHICLE_TYPE = SCHEMA_NAME + "Proc_UpdateVehicleMaster";
        public const string GET_VEHICLE_MASTER = SCHEMA_NAME + "Proc_GetVehicleMaster";
        public const string GET_VISITOR_TYPE = SCHEMA_NAME + "Proc_GetVisitorType";        
        public const string ADD_VISITOR_TYPE = SCHEMA_NAME + "Proc_AddVisitorType";
        public const string UPDATE_VISITOR_TYPE = SCHEMA_NAME + "Proc_UpdateVisitorType";
        public const string GET_FLAT_OCCUPANCY_MASTER = SCHEMA_NAME + "Proc_GetFlatOccupanyMaster";        
        public const string UPDATE_FLAT_OCCUPANCY_MASTER = SCHEMA_NAME + "Proc_UpdateFlatOccupanyMaster";
        public const string ADD_FLAT_PAYMENTS = SCHEMA_NAME + "Proc_AddFlatPayments";
        public const string UPDATE_FLAT_PAYMENTS = SCHEMA_NAME + "Proc_UpdateFlatPayments";
        public const string GET_FLAT_PAYMENT_LIST = SCHEMA_NAME + "Proc_GetFlatPaymentsList";
        public const string GET_FLAT_PAYMENT_DETAILS = SCHEMA_NAME + "Proc_GetFlatPaymentsDetails";
        public const string ADD_FLATS_BILLING = SCHEMA_NAME + "Proc_AddFlatsBilling";
        public const string UDATE_FLATS_BILLING = SCHEMA_NAME + "Proc_UpdateFlatsBilling";
        public const string GET_FLATS_BILLING = SCHEMA_NAME + "Proc_GetFlatsBilling";
        public const string ADD_FREE_REGISTRATION= SCHEMA_NAME + "Proc_AddFreeRegistration";
        public const string GET_FREE_REGISTRATION = SCHEMA_NAME + "Proc_GetFreeRegistration";
        public const string ADD_OCCUPANCY_MASTER = SCHEMA_NAME + "Proc_AddOccupancyMaster";
        public const string UPDATE_OCCUPANCY_MASTER = SCHEMA_NAME + "Proc_UpdateOccupancyMaster";
        public const string ADD_PARKING_MASTER = SCHEMA_NAME + "Proc_AddParkingMaster";
        public const string UPDATE_PARKING_MASTER = SCHEMA_NAME + "Proc_UpdateParkingMaster";
        public const string GET_PARKING_MASTER = SCHEMA_NAME + "Proc_GetParkingMaster";
        public const string GET_PARKING_RECORD = SCHEMA_NAME + "Proc_GetParkingRecord";
        public const string ADD_PARKING_RECORD = SCHEMA_NAME + "Proc_AddParkingRecord";
        public const string UPDATE_PARKING_RECORD = SCHEMA_NAME + "Proc_UpdateParkingRecord";
        public const string UPDATE_PAYMENT_MASTER = SCHEMA_NAME + "Proc_UpdatePaymentMaster";
        public const string ADD_PAYMENT_MASTER = SCHEMA_NAME + "Proc_AddPaymentMaster";
        public const string GET_PAYMENT_MASTER = SCHEMA_NAME + "Proc_GetPaymentMaster";
        public const string GET_ROLE_MASTER = SCHEMA_NAME + "Proc_GetRoleMaster";
        public const string ADD_ROLE_MASTER = SCHEMA_NAME + "Proc_AddRoleMaster";
        public const string UPDATE_ROLE_MASTER = SCHEMA_NAME + "Proc_UpdateRoleMaster";
        public const string ADD_SOCIEY_BILLING_MASTER = SCHEMA_NAME + "Proc_AddSocietyBillingMaster";
        public const string UPDATE_SOCIEY_BILLING_MASTER = SCHEMA_NAME + "Proc_UpdateSocietyBillingMaster";
        public const string GET_SOCIEY_BILLING_MASTER = SCHEMA_NAME + "Proc_GetSocietyBillingMaster";
        public const string ADD_SOCIEY_MEMBER_MASTER = SCHEMA_NAME + "Proc_AddSocietyMemberMaster";
        public const string UPDATE_SOCIEY_MEMBER_MASTER = SCHEMA_NAME + "Proc_UpdateSocietyMemberMaster";
        public const string ADD_SOCIEY_NOMINATION_REGISTER = SCHEMA_NAME + "Proc_AddSocietyNominationRegister";
        public const string UPDATE_SOCIEY_NOMINATION_REGISTER = SCHEMA_NAME + "Proc_UpdateSocietyNominationRegister";
        public const string ADD_SOCIEY_PAYMENTS = SCHEMA_NAME + "Proc_AddSocietyPayments";
        public const string UPDATE_SOCIEY_PAYMENTS = SCHEMA_NAME + "Proc_UpdateSocietyPayments";
        public const string GET_SOCIEY_PAYMENTS_DETAILS = SCHEMA_NAME + "Proc_GetSocietyPaymentsDetails";
        public const string GET_SOCIEY_VISITOR_DETAILS_DATEWISE = SCHEMA_NAME + "Proc_GetSocietyVisitorsDetailsDateWise";
        public const string GET_SOCIETY_COMMITTEE_MEMBERS = SCHEMA_NAME+ "Proc_GetCommitteeMemebers";
        public const string ADD_SOCIETY_COMMITTEE_MEMBERS = SCHEMA_NAME + "Proc_AddCommitteeMembers";
        public const string UPDATE_SOCIETY_COMMITTEE_MEMBERS = SCHEMA_NAME + "Proc_UpdateCommitteeMembers";
        public const string GET_SOCIETY_FLATS_BILLS_DETAILS = SCHEMA_NAME + "Proc_GetSocietyFlatBillsDetails";
        public const string ADD_SOCIETY_FLATS_BILLS_DETAILS = SCHEMA_NAME + "Proc_AddSocietyFlatBillsDetails";
        public const string UPDATE_SOCIETY_FLATS_BILLS_DETAILS = SCHEMA_NAME + "Proc_UpdateSocietyFlatBillsDetails";
        public const string GET_SOCIETY_MEETINGS = SCHEMA_NAME + "Proc_GetSocietyMeetings";
        public const string ADD_SOCIETY_MEETINGS = SCHEMA_NAME + "Proc_AddSocietyMeetings";
        public const string UPDATE_SOCIETY_MEETINGS = SCHEMA_NAME + "Proc_UpdateSocietyMeetings";
        public const string GET_SOCIETY_MEMBER_MASTER = SCHEMA_NAME + "Proc_GetSocietyMemberMaster";
        public const string ADD_SOCIETY_VISITORS = SCHEMA_NAME + "Proc_AddSocietyVisitors";
        public const string UPDATE_SOCIETY_VISITORS = SCHEMA_NAME + "Proc_UpdateSocietyVisitors";
        public const string GET_USER_LIST = SCHEMA_NAME + "Proc_GetUserList";
        public const string GET_USER_DETAILS = SCHEMA_NAME + "Proc_GetUserMasterDetails";
        public const string GET_ALL_USER_DETAILS = SCHEMA_NAME + "Proc_GetALLUserMasterDetails";
        public const string ADD_USERS_MASTER = SCHEMA_NAME + "Proc_AddUserMaster";
        public const string UPDATE_USERS_MASTER = SCHEMA_NAME + "Proc_UpdateUserMaster";
        public const string GET_FLAT_TYPE_MASTER=SCHEMA_NAME +"Proc_GetFlatsType";
        public const string ADD_FLAT_TYPE_MASTER=SCHEMA_NAME + "Proc_AddFlatType";
        public const string UPDATE_FLAT_TYPE_MASTER = SCHEMA_NAME + "Proc_UpdateFlatType";

    }
}
