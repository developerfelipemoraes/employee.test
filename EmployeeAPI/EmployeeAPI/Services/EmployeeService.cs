using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Employee employee) => await _repository.CreateAsync(employee);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}