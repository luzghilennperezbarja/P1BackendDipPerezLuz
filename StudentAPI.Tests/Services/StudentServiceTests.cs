using StudentAPI.Models;
using StudentAPI.Services;
using Xunit;

namespace StudentAPI.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            _studentService = new StudentService();
        }

        [Fact]
        public void HasApproved_WithNoteGreaterThan51_ReturnsTrue()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 75
            };

            // Act
            var result = _studentService.HasApproved(estudiante);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasApproved_WithNoteEqualTo51_ReturnsTrue()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 51
            };

            // Act
            var result = _studentService.HasApproved(estudiante);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasApproved_WithNoteLessThan51_ReturnsFalse()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 50
            };

            // Act
            var result = _studentService.HasApproved(estudiante);

            // Assert
            Assert.False(result);
        }
    }
}
