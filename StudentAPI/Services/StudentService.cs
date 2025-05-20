using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        public bool HasApproved(Student student)
        {
            return student.Nota >= 51;
        }
    }
}