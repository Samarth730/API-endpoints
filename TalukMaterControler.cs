using Microsoft.AspNetCore.Mvc;
using TalukMasterInformation.Model;
using TalukMasterInformation.BissnussLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalukMasterInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalukMaterControler : ControllerBase
    {
        BLTalukMater bLTalukMater = new BLTalukMater();
        List<BOTalukMaster> bOTalukMasters = new List<BOTalukMaster>();
        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetTalukMasterDetails()
        {
            BLTalukMater bLTalukMater = new BLTalukMater();
            List<BOTalukMaster> bOTalukMasters = new List<BOTalukMaster>();
            bOTalukMasters = bLTalukMater.GetTalukMasterDetails();
            return Ok(bOTalukMasters);
            
                
        }
        [HttpGet]
        [Route("getId")]
        public IActionResult GetSingalTaluk([FromQuery] string DistrictId)

        {
            
            bOTalukMasters = bLTalukMater.GetSingalTaluk(DistrictId);
            return Ok(bOTalukMasters);
            
        }



        [HttpPost]
        [Route("Insert")]
        public IActionResult InsertingTalukDetsils(int Id, string TalukName, string DistrictId)
        {
            bool strim = bLTalukMater.InsertDeatails(Id, TalukName, DistrictId);
            return strim ? Ok("data insert sucsfully") : Ok("Data not inserted");

        }
        [HttpPut]
        [Route("update")]

        public IActionResult UpdateDeatails([FromQuery]int Id,string TalukName,string DistrictId)
        {
            bool up = bLTalukMater.UpdateDeatails(Id,TalukName,DistrictId);
            return up? Ok("Data updated succesfully"):StatusCode(500);
        }


        [HttpDelete]
        [Route("Delete")]

        public IActionResult Deletee( int Id)
        {
            bool up = bLTalukMater.Deletee(Id);
            return up ? Ok("Data deleted fully") : StatusCode(500);
        }




    }
}
