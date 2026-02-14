using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharpPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "pavu", "vedant", "rachana" };
            return Ok(studentNames);
        }
    }
}
