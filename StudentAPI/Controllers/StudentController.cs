using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("hasapproved")]
        public ActionResult<bool> HasApproved([FromBody] Student student)
        {
            var result = _studentService.HasApproved(student);
            return Ok(result);
        }
    }
}