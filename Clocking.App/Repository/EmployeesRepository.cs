using Clocking.App.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Clocking.App.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly string _connectionString;

        public EmployeesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Employees (FirstName, LastName, Email, Contact, Position, DepartmentID) VALUES (@FirstName, @LastName, @Email, @Contact, @Position, @DepartmentID)";
                await connection.ExecuteAsync(query, employee);
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Contact = @Contact, Position = @Position, DepartmentID = @DepartmentID WHERE Id = @Id";
                await connection.ExecuteAsync(query, employee);
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Employees WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = employeeId });
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Employees WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = employeeId });
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Employees";
                return await connection.QueryAsync<Employee>(query);
            }
        }
    }
}