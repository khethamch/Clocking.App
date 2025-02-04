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
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly string _connectionString;

        public EmployeeLeaveRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public object EmployeeId { get; private set; }

        public async Task CreateEmployeeLeave(EmployeeLeave employeeLeave)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO EmployeeLeave (EmployeeID, LeaveType, StartDate, EndDate ) VALUES (@EmployeeID, @LeaveType, @StartDate, @EndDate)";
                await connection.ExecuteAsync(query, employeeLeave);
            }
           
        }

        public async Task DeleteEmployeeLeave(int EmployeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM EmployeeLeave WHERE Id = @ID";
                await connection.ExecuteAsync(query, new { Id = EmployeeId });
            }
         
        }

        public async Task<EmployeeLeave> GetEmployeeLeave(int EmployeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM EmployeeLeave WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<EmployeeLeave>(query, new { Id = EmployeeId });
            }
            
        }

        public async Task<IEnumerable<EmployeeLeave>> GetEmployeeLeaves()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM EmployeeLeave";
                return await connection.QueryAsync<EmployeeLeave>(query);

            }

           
        }

        public async Task UpdateEmployeeLeave(EmployeeLeave employeeLeave)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE  EmployeeLeave SET  EmployeeId = @EmployeeId LeaveType = @LeaveType, StartDate = @StartDate, EndDate = @EndDate  WHERE Id = @Id";
                await connection.ExecuteAsync(query, employeeLeave);
            }

            
        }

    }
}