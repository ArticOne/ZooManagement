using Microsoft.AspNetCore.Mvc;

namespace ZooManagement.API.Controllers
{
    [ApiController]
    [Route("_health")]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
