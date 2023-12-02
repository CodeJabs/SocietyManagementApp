namespace Models
{
    public class SocietyBillingMaster
    {
        private int _id;
        private Society _society;
        private SocietyServicePackage _societyServicePackage;
        private double _standardPricing;
        private double _sgst;
        private double _cgst;        
        private double _totalPrice;
        private double _electricity;
        private double _water;
        private double _property;
        private double _otherExpenses;


        public int Id { get { return _id; } set { _id = value; } }
        public Society Society { get { return _society; } set { _society = value; } }

        public SocietyServicePackage SocietyServicePackage { get { return _societyServicePackage; } set { _societyServicePackage = value; } }
        public double StandardPricing { get { return _standardPricing; } set { _standardPricing = value; } }
        public double SGST { get { return _sgst; } set { _sgst = value; } }
        public double CGST { get { return _cgst; } set { _cgst = value; } }
        
        public double TotalPrice { get { return _totalPrice; } set { _totalPrice = value; } }
        public double Electricity { get { return _electricity; } set { _electricity = value; } }
        public double Water { get { return _water; } set { _water = value; } }
        public double Property { get { return _property; } set { _property = value; } }
        public double OtherExpenses { get { return _otherExpenses; } set { _otherExpenses = value; } }
        
    }
}
