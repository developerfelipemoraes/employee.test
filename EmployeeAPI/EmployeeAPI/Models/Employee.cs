using System.Collections.Generic;

namespace EmployeeAPI.Models
{
    public class Employee
    {
       
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocNumber { get; set; }
        public List<string> Phones { get; set; }
        public string? ManagerId { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}