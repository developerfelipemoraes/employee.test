using EmployeeAPI.Controllers;
using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeService> _serviceMock;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _serviceMock = new Mock<IEmployeeService>();
            _controller = new EmployeeController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Employee { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
            };
            _serviceMock.Setup(svc => svc.GetAllAsync()).ReturnsAsync(employees);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployees = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Equal(2, returnedEmployees.Count);
        }
    }
}