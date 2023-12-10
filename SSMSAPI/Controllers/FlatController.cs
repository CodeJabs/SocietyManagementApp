using DataAccessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using dam = DataAccessManager.Operations;



namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
<<<<<<< HEAD
    //[ApiController]
=======
    [ApiController]
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
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
<<<<<<< HEAD
        public IActionResult GetFlatlist([FromBody] Society society)
=======
        public IActionResult GetFlatlist(Society society)
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
        {
            try
            {
                var data = IflatDetails.GetFlatsList(society);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<FlatDetails> flatDetails = new List<FlatDetails>();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    flatDetails.Add(new FlatDetails { ID = Convert.ToInt32(item["ID"]), FlatNo = Convert.ToInt32("FlatNo") });
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
<<<<<<< HEAD
        public IActionResult GetFlatDetails([FromBody] Society society, [FromBody] FlatDetails flatDetails)
=======
        public IActionResult GetFlatDetails(Society society, FlatDetails flatDetails)
>>>>>>> e6e14b94aa92292adb2cde8ad349c468eb6c2015
        {
            try
            {
                var data = IflatDetails.GetFlatDetails(society, flatDetails);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                flatDetails.FlatOwner = Convert.ToString(data.Tables[0].Rows[0]["FlatOwner"]);
                flatDetails.ContactNo = Convert.ToString(data.Tables[0].Rows[0]["ContactNo"]);
                flatDetails.FlatOccupanyMaster = new FlatOccupancyMaster();
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

        public IActionResult Save([FromBody] Society society, [FromBody] FlatDetails flatDetails, [FromBody] FlatOccupancyMaster flatOccupancyMaster)
        {
            try
            {
                IflatDetails.Save(society, flatDetails, flatOccupancyMaster);
                return Ok(flatDetails);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Flat/UpdateFlat")]

        public IActionResult Update([FromBody] Society society, [FromBody] FlatDetails flatDetails, [FromBody] FlatOccupancyMaster flatOccupancyMaster)
        {
            try
            {
                IflatDetails.Update(society, flatDetails, flatOccupancyMaster);
                return Ok(flatDetails);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
