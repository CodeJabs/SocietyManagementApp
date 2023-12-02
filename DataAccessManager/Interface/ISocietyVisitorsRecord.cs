using System.Data;
using System;

namespace DataAccessManager.Interface
{
    public interface ISocietyVisitorsRecord
    {
        DataSet GetVisitorRecordByDateWise(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime);
        Models.SocietyVisitorsRecord Add(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime);
        Models.SocietyVisitorsRecord Update(Models.SocietyVisitorsRecord societyVisitorsRecord, Models.FlatDetails flatDetails, DateTime entryDateTime);
    }
}
