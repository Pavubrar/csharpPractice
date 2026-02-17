using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharpPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {return Ok(new{
            sevice = "Healthservice",
            status = "Running",
            timestamp = DateTime.UtcNow

        });
        }
    }
}
