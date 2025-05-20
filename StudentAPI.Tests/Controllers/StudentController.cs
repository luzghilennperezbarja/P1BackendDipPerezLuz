using Xunit;
using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace StudentAPI.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void HasApproved_ReturnsOkResult_WithExpectedValue()
        {
            var mockService = new Mock<IStudentService>();
            var student = new Student { CI = 1, Nombre = "Test", Nota = 80 };
            mockService.Setup(s => s.HasApproved(student)).Returns(true);

            var controller = new StudentController(mockService.Object);

            var result = controller.HasApproved(student);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}