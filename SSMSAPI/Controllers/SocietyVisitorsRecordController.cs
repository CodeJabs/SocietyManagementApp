using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
using DataAccessManager.Interface;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyVisitorsRecordController : ControllerBase
    {
        ISocietyVisitorsRecord IsocietyVisitorRec = null;
        mod.SocietyVisitorsRecord societyVisitorsRecord = null; 
        public SocietyVisitorsRecordController()
        {
            IsocietyVisitorRec = new dam.SocietyVisitorsRecord();
            societyVisitorsRecord = new mod.SocietyVisitorsRecord();

         }

        [HttpGet]
        [Route("SocietyVisitorsRecord/GetVisitorRecordByDate")]
        public IActionResult GetVisitorRecord(mod.SocietyVisitorsRecord societyVisitorsRecord)
        {
            try
            {
                var data = IsocietyVisitorRec.GetVisitorRecordByDateWise(societyVisitorsRecord,null, societyVisitorsRecord.EntryTime);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyVisitorsRecord> societyVisitorsRecords = new List<mod.SocietyVisitorsRecord>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyVisitorsRecords.Add(new mod.SocietyVisitorsRecord
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        FromLocation = Convert.ToString(dr["FromLocation"]),
                        Name = Convert.ToString(dr["Name"]),
                        EntryTime = Convert.ToDateTime(dr["EntryTime"]),
                        OutTime = Convert.ToDateTime(dr["OutTime"]),
                        ContactNo = Convert.ToInt32(dr["Contact"])
                        

                    });
                }
                return Ok(societyVisitorsRecords);
            }
            catch (Exception ex)
            {

                return  BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyVisitorsRecord/AddVisitorRecord")]
        public IActionResult AddVisitorRecord(mod.SocietyVisitorsRecord societyVisitorsRecord)
        {
            try
            {
                 IsocietyVisitorRec.Add(societyVisitorsRecord,null,DateTime.Now);
                
                return Ok(societyVisitorsRecord);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyVisitorsRecord/UpdateVisitorRecord")]
        public IActionResult UpdateVisitorRecord(mod.SocietyVisitorsRecord societyVisitorsRecord)
        {
            try
            {
                IsocietyVisitorRec.Update(societyVisitorsRecord, null, DateTime.Now);

                return Ok(societyVisitorsRecord);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
