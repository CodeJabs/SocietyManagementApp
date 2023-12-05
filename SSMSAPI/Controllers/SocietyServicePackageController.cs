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
    public class SocietyServicePackageController : ControllerBase
    {
        ISocietySevicePackage IsocietyServicePackage = null;
        mod.SocietyServicePackage societyServicePackage = null;
        public SocietyServicePackageController()
        {
            IsocietyServicePackage = new dam.SocietyServicePackage();
            societyServicePackage = new mod.SocietyServicePackage();
        }

        [HttpGet]
        [Route("SocietyServicePackage/GetSocietyPackages")]
        public IActionResult GetPackages()
        {
            try
            {
                var data = IsocietyServicePackage.GetSocietyServicePackage();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyServicePackage> societyServicePackages = new List<mod.SocietyServicePackage>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyServicePackages.Add(new mod.SocietyServicePackage
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Type = Convert.ToString(dr["Type"]),
                        PackagePrice = Convert.ToInt32(dr["PackagePrice"])
                    });
                }
                return Ok(societyServicePackages);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("SocietyServicePackage/GetSocietyPackagesDetails")]
        public IActionResult GetPackagesDetails(int PackageID)
        {
            try
            {
                var data = IsocietyServicePackage.GetSocietyServicePackageDetails(PackageID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                societyServicePackage.ID = Convert.ToInt32(data.Tables[0].Rows[0]["ID"]);
                societyServicePackage.Type = Convert.ToString(data.Tables[0].Rows[0]["Type"]);
                societyServicePackage.PackagePrice = Convert.ToInt32(data.Tables[0].Rows[0]["PackagePrice"]);              
                return Ok(societyServicePackage);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyServicePackage/AddSocietyPackagesDetails")]
        public IActionResult AddNewPackage(mod.SocietyServicePackage societyServicePackage)
        {
            try
            {
              IsocietyServicePackage.Save(societyServicePackage);
               
                return Ok(societyServicePackage);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("SocietyServicePackage/UpdateSocietyPackagesDetails")]
        public IActionResult UpdatePackage(mod.SocietyServicePackage societyServicePackage)
        {
            try
            {
                IsocietyServicePackage.Update(societyServicePackage);

                return Ok(societyServicePackage);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
