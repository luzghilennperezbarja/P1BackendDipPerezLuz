using StudentAPI.Models;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        public bool HasApproved(Estudiante estudiante)
        {
            // Nota de aprobación: 51
            return estudiante.Nota >= 51;
        }
    }
}