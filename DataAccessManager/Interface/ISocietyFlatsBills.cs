

using System.Data;

namespace DataAccessManager.Interface
{
    public interface ISocietyFlatsBills
    {
        DataSet GetFlatsForSocietyBills(Models.Society society, Models.FlatDetails flatDetails);

        Models.SocietyFlatsBills Add(Models.Society society, Models.FlatDetails flatDetails, Models.SocietyFlatsBills societyFlatsBills);

        Models.SocietyFlatsBills Update(Models.Society society, Models.FlatDetails flatDetails, Models.SocietyFlatsBills societyFlatsBills);
    }
}
