using Microsoft.AspNetCore.Mvc;
using StudentAPI.Services;
using StudentAPI.Models;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("{ci}")]
        public ActionResult<Student> GetStudentByCI(int ci)
        {
            var student = _studentService.GetByCI(ci);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            var createdStudent = _studentService.Create(student);
            return CreatedAtAction(nameof(GetStudentByCI), new { ci = createdStudent.CI }, createdStudent);
        }

        [HttpPut("{ci}")]
        public ActionResult<Student> UpdateStudent(int ci, [FromBody] Student student)
        {
            if (ci != student.CI)
                return BadRequest();

            var updated = _studentService.Update(ci, student);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{ci}")]
        public ActionResult<Student> DeleteStudent(int ci)
        {
            var deleted = _studentService.Delete(ci);
            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}