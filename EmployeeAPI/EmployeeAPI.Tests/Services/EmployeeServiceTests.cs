using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using EmployeeAPI.Services;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Employee { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count);
        }
    }
}