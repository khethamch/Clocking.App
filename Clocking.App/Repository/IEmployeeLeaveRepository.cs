using Clocking.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface IEmployeeLeaveRepository
    {
        Task CreateEmployeeLeave(EmployeeLeave employeeLeave);
        Task UpdateEmployeeLeave(EmployeeLeave employeeLeave);
        Task DeleteEmployeeLeave(int EmployeeID);
        Task <EmployeeLeave> GetEmployeeLeave(int EmployeeID);
        Task <IEnumerable<EmployeeLeave>> GetEmployeeLeaves();
    }
}
