using Clocking.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface IEmployeesRepository
    {
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task GetEmployee(int employeeId);
        Task GetEmployees();
    }
}