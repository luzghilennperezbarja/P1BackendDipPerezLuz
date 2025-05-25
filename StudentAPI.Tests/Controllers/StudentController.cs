using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using Xunit;

namespace StudentAPI.Tests.Controllers
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockStudentService;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
            _controller = new StudentController(_mockStudentService.Object);
        }

        [Fact]
        public void CheckIfStudentApproved_WithApprovedStudent_ReturnsTrue()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 75
            };

            _mockStudentService.Setup(service => service.HasApproved(It.IsAny<Estudiante>()))
                .Returns(true);

            // Act
            var result = _controller.CheckIfStudentApproved(estudiante);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            Assert.NotNull(value);
            Assert.True((bool)value);
            _mockStudentService.Verify(service => service.HasApproved(It.IsAny<Estudiante>()), Times.Once);
        }

        [Fact]
        public void CheckIfStudentApproved_WithFailedStudent_ReturnsFalse()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                CI = 12345,
                Nombre = "Juan Pérez",
                Nota = 45
            };

            _mockStudentService.Setup(service => service.HasApproved(It.IsAny<Estudiante>()))
                .Returns(false);

            // Act
            var result = _controller.CheckIfStudentApproved(estudiante);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value;
            Assert.NotNull(value);
            Assert.False((bool)value);
            _mockStudentService.Verify(service => service.HasApproved(It.IsAny<Estudiante>()), Times.Once);
        }

        [Fact]
        public void GetStudentInfo_ReturnsCorrectStudentData()
        {
            // Arrange
            int ci = 54321;
            string nombre = "María López";
            int nota = 85;

            // Act
            var result = _controller.GetStudentInfo(ci, nombre, nota);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var estudiante = Assert.IsType<Estudiante>(okResult.Value);
            
            Assert.Equal(54321, estudiante.CI);
            Assert.Equal("María López", estudiante.Nombre);
            Assert.Equal(85, estudiante.Nota);
        }
    }
}
