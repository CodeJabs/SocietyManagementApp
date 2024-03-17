using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BillingQuaterMaster
    {
        private int _id;
        private string _quaterType;

        public int ID { get { return _id; } set { _id = value; } }
        public string QuaterType { get { return _quaterType; } set { _quaterType = value; } }

    }
}
