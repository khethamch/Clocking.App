using Clocking.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(int Id);
        Task<Company> GetCompany(int Id);
        Task<IEnumerable<Company>> GetCompanies();
    }
}
