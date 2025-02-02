using Clocking.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface IEmployeesRepository
    {
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<Employee> GetEmployee(int employeeId);
        Task<IEnumerable<Employee>> GetEmployees();
    }
}