using EmployeeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task CreateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}