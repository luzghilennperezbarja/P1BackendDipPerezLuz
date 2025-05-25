using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        bool HasApproved(Estudiante estudiante);
    }
}