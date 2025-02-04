using Clocking.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface IDepartmentRepository
    {
        Task CreateDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int ID);
        Task<Department> GetDepartment(int ID);
        Task<IEnumerable< Department>> GetDepartments();

    }
}
