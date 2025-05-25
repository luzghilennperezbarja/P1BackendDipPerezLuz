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

        [HttpPost("check-approval")]
        public IActionResult CheckIfStudentApproved([FromBody] Estudiante estudiante)
        {
            return Ok(_studentService.HasApproved(estudiante));
        }

        [HttpGet("info")]
        public IActionResult GetStudentInfo([FromQuery] int ci, [FromQuery] string nombre, [FromQuery] int nota)
        {
            var estudiante = new Estudiante
            {
                CI = ci,
                Nombre = nombre,
                Nota = nota
            };
            
            return Ok(estudiante);
        }
    }
}