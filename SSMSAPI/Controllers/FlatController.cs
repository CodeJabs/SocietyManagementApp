using DataAccessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using dam = DataAccessManager.Operations;



namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
   
    [ApiController]

    public class FlatController : ControllerBase
    {
        FlatDetails flatDetails = null;
        IFlatDetails IflatDetails = null;
        public FlatController()
        {
            flatDetails = new FlatDetails();
            IflatDetails = new dam.FlatDetails();
        }

        [HttpGet]
        [Route("Flat/FlatList")]        
 
        public IActionResult GetFlatlist(int societyID)

        {
            try
            {
                var data = IflatDetails.GetFlatsList(societyID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<FlatDetails> flatDetails = new List<FlatDetails>();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    flatDetails.Add(new FlatDetails { ID = Convert.ToInt32(item["ID"]), FlatNo = Convert.ToInt32(item["FlatNo"]) });
                }

                return Ok(flatDetails);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }


        }
        [HttpGet]
        [Route("Flat/GetFlatDetails")]
 
        public IActionResult GetFlatDetails(int societyID , int flatNo)        

        {
            try
            {
                var data = IflatDetails.GetFlatDetails(societyID, flatNo);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                flatDetails.ID = Convert.ToInt32(data.Tables[0].Rows[0]["ID"]);
                flatDetails.FlatNo = Convert.ToInt32(data.Tables[0].Rows[0]["FlatNo"]);
                flatDetails.FlatOwner = Convert.ToString(data.Tables[0].Rows[0]["FlatOwner"]);
                flatDetails.ContactNo = Convert.ToString(data.Tables[0].Rows[0]["ContactNo"]);
                flatDetails.FlatOccupanyMaster = new FlatOccupancyMaster();
                flatDetails.FlatOccupanyMaster.ID = Convert.ToInt32(data.Tables[0].Rows[0]["OccupancyID"]);
                flatDetails.FlatOccupanyMaster.OccupancyType = Convert.ToString(data.Tables[0].Rows[0]["OccupancyType"]);

                return Ok(flatDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("Flat/AddNewFlat")]

        public IActionResult Save([FromBody] FlatDetails flatDetails)
        {
            try
            {
                IflatDetails.Save(flatDetails.Society, flatDetails, flatDetails.FlatOccupanyMaster);
                return Ok(flatDetails);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Flat/UpdateFlat")]

        public IActionResult Update([FromBody] FlatDetails flatDetails)
            {
            try
            {
                IflatDetails.Update(flatDetails.Society, flatDetails, flatDetails.FlatOccupanyMaster);
                return Ok(flatDetails);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
