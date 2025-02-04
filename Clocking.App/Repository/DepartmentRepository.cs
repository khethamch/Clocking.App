using Clocking.App.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Clocking.App.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CreateDepartment(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Department (Name, Description, CompanyID, ID ) VALUES(Name = @Name, Description = @Description, CompanyID = @CompanyID WHERE ID = @ID )";
                await connection.ExecuteAsync(query, department);
            }
            throw new NotImplementedException();
        }

        public async Task DeleteDepartment(int ID)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Department WHERE ID = @ID";
                await connection.ExecuteAsync(query, new { ID = ID });
            }
            throw new NotImplementedException();
        }

        public async Task<Department> GetDepartment(int ID)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Department WHERE ID = @ID";
                return await   connection.QueryFirstOrDefaultAsync<Department>(query, new { ID = ID });
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * from Department";
                return await connection.QueryAsync<Department>(query);
            }
            throw new NotImplementedException();
        }

        public async Task UpdateDepartment(Department department)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                var query = "UPDATE  Departments SET Name = @Name, Description = @Description, CompanyID = @CompanyID WHERE ID = @ID ";
                await connection.ExecuteAsync(query, department);
            }
            throw new NotImplementedException();
        }
    }
}