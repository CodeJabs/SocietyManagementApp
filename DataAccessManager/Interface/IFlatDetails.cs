

using System.Data;

namespace DataAccessManager.Interface
{
   public interface IFlatDetails
    {
        DataSet GetFlatsList(int societyID);

        DataSet GetFlatDetails(Models.Society society, Models.FlatDetails flatDetails);

        Models.FlatDetails Save(Models.Society society, Models.FlatDetails flatDetails, Models.FlatOccupancyMaster flatOccupancyMaster);

        Models.FlatDetails Update(Models.Society society, Models.FlatDetails flatDetails, Models.FlatOccupancyMaster flatOccupancyMaster);
    }
}
