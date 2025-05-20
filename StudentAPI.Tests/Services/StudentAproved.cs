using Xunit;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Tests
{
    public class StudentServiceTests
    {
        [Fact]
        public void HasApproved_ReturnsTrue_WhenNotaIsGreaterOrEqual51()
        {
            var student = new Student { CI = 1, Nombre = "Juan", Nota = 80 };
            var service = new StudentService();

            Assert.True(service.HasApproved(student));
        }

        [Fact]
        public void HasApproved_ReturnsFalse_WhenNotaIsLessThan51()
        {
            var student = new Student { CI = 2, Nombre = "Ana", Nota = 40 };
            var service = new StudentService();

            Assert.False(service.HasApproved(student));
        }

        [Fact]
        public void Student_Nombre_IsCorrect()
        {
            var student = new Student { CI = 3, Nombre = "Pedro", Nota = 60 };
            Assert.Equal("Pedro", student.Nombre);
        }

        [Fact]
        public void Student_CI_IsCorrect()
        {
            var student = new Student { CI = 123, Nombre = "Maria", Nota = 70 };
            Assert.Equal(123, student.CI);
        }
    }
}