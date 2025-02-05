using Clocking.App.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Clocking.App.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateCompany(Company company)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                var query = "INSERT INTO Company (Name, RegistrationNumber, DateCreated, ContactNumber, EmailAddress, IsActive) VALUES(@Name, @RegistrationNumber, @DateCreated, @ContactNumber, @EmailAddress, @IsActive)";
                await connection.ExecuteAsync(query, company);
            }
        }

        public async Task UpdateCompany(Company company)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Company SET Name = @Name, RegistrationNumber = @RegistrationNumber, DateCreated = @DateCreated, ContactNumber = @ContactNumber, EmailAddress = @EmailAddress, IsActive = @IsActive WHERE Id = @Id";
                await connection.ExecuteAsync(query, company);
            }
        }

        public async Task DeleteCompany(int companyId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Company WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = companyId });
            }
        }

        public async Task<Company> GetCompany(int companyId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Company WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Company>(query, new { Id = companyId });
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Company";
                return await connection.QueryAsync<Company>(query);
            }
        }

        
    }
}