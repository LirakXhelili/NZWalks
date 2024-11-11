using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NEZWalksAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET:https//localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Lirak", "Lorik", "Malsore", "Olt" };

            return Ok(studentNames);
        }
    }
}
