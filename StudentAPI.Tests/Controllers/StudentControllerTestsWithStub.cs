using Microsoft.AspNetCore.Mvc;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using StudentAPI.Tests.Services;
using Xunit;

namespace StudentAPI.Tests.Controllers
{
    public class StudentControllerTestsWithStub
    {
        [Fact]
        public void CheckIfStudentApproved_WithStubReturningTrue_ReturnsTrue()
        {
            // Arrange
            // Usamos nuestro stub manual en lugar de Moq
            var studentServiceStub = new StudentServiceStub(true);
            var controller = new StudentController(studentServiceStub);
            
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 75
            };

            // Act
            var result = controller.CheckIfStudentApproved(estudiante);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            Assert.NotNull(value);
            Assert.True((bool)value);
        }

        [Fact]
        public void CheckIfStudentApproved_WithStubReturningFalse_ReturnsFalse()
        {
            // Arrange
            // Usamos nuestro stub manual en lugar de Moq
            var studentServiceStub = new StudentServiceStub(false);
            var controller = new StudentController(studentServiceStub);
            
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 45
            };

            // Act
            var result = controller.CheckIfStudentApproved(estudiante);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            Assert.NotNull(value);
            Assert.False((bool)value);
        }
    }
}
