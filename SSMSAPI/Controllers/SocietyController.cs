﻿using DataAccessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using dam = DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        Society society = null;
        ISociety ISociety = null;
        public SocietyController()
        {
            society = new Society();
            ISociety = new  dam.Society();

        }

        [HttpGet]
        [Route("Society/GetSocieties")]

        public IActionResult GetAllSocieties()
        {
            try
            {
                var data = ISociety.GetSocieties();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<Society> societies = new List<Society>();

                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societies.Add(new Society
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                    });
                }
                return Ok(societies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally { }

            
        }


        [HttpGet]
        [Route("Society/GetSocietyDetails")]
        public IActionResult GetSocietyDetails(int societyID)

        {
            try
            {
                var data = ISociety.GetSocietyDetails(societyID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                Society society = new Society();  
                society.ID = Convert.ToInt32(data.Tables[0].Rows[0]["ID"]);
                society.Name = Convert.ToString(data.Tables[0].Rows[0]["Name"]);
                society.Abbreviation = Convert.ToString(data.Tables[0].Rows[0]["Abbreviation"]);
                society.Address = Convert.ToString(data.Tables[0].Rows[0]["Address"]);
                society.TelephoneNumber = Convert.ToInt32(data.Tables[0].Rows[0]["TelePhoneNumber"]);
                society.societyServicePackage = new SocietyServicePackage();
                society.societyServicePackage.ID= Convert.ToInt32(data.Tables[0].Rows[0]["PackageID"]);
                society.societyServicePackage.Type = Convert.ToString(data.Tables[0].Rows[0]["PackageType"]);
                society.societyServicePackage.PackagePrice = Convert.ToInt32(data.Tables[0].Rows[0]["PackagePrice"]);

                return Ok(society);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("Society/AddNewSocitey")]

        public IActionResult Save([FromBody] Society society)
        {
            try
            {
                ISociety.Save(society);
                return Ok(society);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {

                //DisposeInstances();
            }
        }
    }
}
