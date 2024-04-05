using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Interface
{
    public interface IFlatTypeMaster
    {
        DataSet GetFlatTypeMasterList();
        
        Models.FlatTypeMaster Save(Models.FlatTypeMaster flatTypeMaster);

        Models.FlatTypeMaster Update(Models.FlatTypeMaster flatTypeMaster);
    }
}
