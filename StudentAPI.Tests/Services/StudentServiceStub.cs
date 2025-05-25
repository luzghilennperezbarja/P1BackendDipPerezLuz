using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Tests.Services
{
    // Esta es una implementación manual de un Stub para IStudentService
    public class StudentServiceStub : IStudentService
    {
        private readonly bool _returnValue;

        // Constructor que permite configurar el valor de retorno
        public StudentServiceStub(bool returnValue)
        {
            _returnValue = returnValue;
        }

        // Implementación que siempre devuelve el valor configurado
        public bool HasApproved(Estudiante estudiante)
        {
            return _returnValue;
        }
    }
}
