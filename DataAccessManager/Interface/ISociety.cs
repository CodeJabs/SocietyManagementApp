using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime;
using System.Text;

namespace DataAccessManager.Interface
{
    public interface ISociety
    {
        public DataSet GetSocieties();

        public DataSet GetSocietyDetails(int SocietyID);

        public Society Save(Society society);
    }
}
