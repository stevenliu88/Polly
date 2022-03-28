using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ResponseController : ControllerBase 
    {
        // Get api/response/100 

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetAResponse(int id)
        {
            Random rnd = new Random();
            var rndInterger = rnd.Next(1, 101);
            if (rndInterger >= id) {
                Console.WriteLine("--> Failure - Generate a Http 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Successful - Generate a Http 200");
            return Ok();  
        }
    }
}
