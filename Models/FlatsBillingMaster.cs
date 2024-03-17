namespace Models
{
    public class FlatsBillingMaster
    {
        private int _id;
        private string _type;
        private double _standardPricing;
        private double _sgst;
        private double _cgst;
        private FlatDetails _flatDetails;
        private double _penalty;
        private double _interestCharges;
        private double _flatTransferCharges;
        private double _parkingCharges;
        private double _nonOccupancyCharges;
        private double _serviceCharges;
        private double _electricityCharges;
        private double _propertyTax;
        private BillingQuaterMaster _billingQuaterMaster;
        public int Id { get { return _id; } set { _id = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public double StandardPricing { get { return _standardPricing; } set { _standardPricing = value; } }
        public double SGST { get { return _sgst; } set { _sgst = value; } }
        public double CGST { get { return _cgst; } set { _cgst = value; } }
        public FlatDetails FlatDetails { get { return _flatDetails; } set { _flatDetails = value; } }
        public double Penalty { get { return _penalty; } set { _penalty = value; } }
        public double InterestCharges { get { return _interestCharges; } set { _interestCharges = value; } }
        public double FlatTransferCharges { get { return _flatTransferCharges; } set { _flatTransferCharges = value; } }
        public double ParkingCharges { get { return _parkingCharges; } set { _parkingCharges = value; } }
        public double NonOccupancyCharges { get { return _nonOccupancyCharges; } set { _nonOccupancyCharges = value; } }
        public double ServiceCharges { get { return _serviceCharges; } set { _serviceCharges = value; } }
        public double ElectricityCharges { get { return _electricityCharges; } set { _electricityCharges = value; } }
        public double PropertyTax { get { return _propertyTax; } set { _propertyTax = value; } }

        public BillingQuaterMaster BillingQuaterMaster {get {return _billingQuaterMaster ;} set { _billingQuaterMaster = value; } }


    }
}
