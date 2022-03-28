using Microsoft.AspNetCore.Mvc;
using RequestServiceWithPolly.Policies;

namespace RequestServiceWithPolly.Controllers
{
    public class RequestController : Controller
    {
        private ClientPolicy _clientPolicy;
        private IHttpClientFactory _clientFactory;

        public RequestController(ClientPolicy clientPolicy, IHttpClientFactory clientFactory)
        {
            _clientPolicy = clientPolicy;
            _clientFactory = clientFactory;
        }
        [Route("api/[controller]")]
        // Get api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest() 
        {
            //var client = new HttpClient();

            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("https://localhost:7056/api/Response/25");

            //var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("https://localhost:7056/api/Response/25"));
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Response service returned Success");
                return Ok();
            }
            Console.WriteLine("--> Response service returned Failure");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

      
    }
}
