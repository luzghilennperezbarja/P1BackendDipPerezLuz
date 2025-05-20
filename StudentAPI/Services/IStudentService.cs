using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        bool HasApproved(Student student);
    }
}