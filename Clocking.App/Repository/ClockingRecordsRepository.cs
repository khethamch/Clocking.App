using Clocking.App.Models;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace Clocking.App.Repository
{
    public class ClockingRecordsRepository : IClockingRecordsRepository
    {
        private readonly string _connectionString;

        public ClockingRecordsRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateRecord(ClockingRecord record)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                var query = "INSERT INTO ClockingRecord (EmployeeID, EmployeeName, Department, TimeIn, TimeOut) VALUES (@EmployeeID, @EmployeeName, @Department, @TimeIn, @TimeOut)";
                await connection.ExecuteAsync(query, record);
            }
        }

        public async Task UpdateRecord(ClockingRecord record)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE ClockingRecord SET EmployeeID = @EmployeeID, EmployeeName = @EmployeeName, Department = @Department, TimeIn= @TimeIn, Timeout = @Timeout";
                await connection.ExecuteAsync(query, record);
            }
        }

        public async Task DeleteRecord(int employeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM ClockingRecord WHERE EmployeeID = @EmployeeID";
                await connection.ExecuteAsync(query, new { EmployeeID = employeeID });
            }
        }

        public async Task<ClockingRecord> GetRecord(int employeeID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM ClockingRecord WHERE EmployeeID = @EmployeeID";
                return await connection.QueryFirstOrDefaultAsync<ClockingRecord>(query, new { EmployeeID = employeeID });
            }
        }

        public async Task<IEnumerable<ClockingRecord>> GetRecords()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM ClockingRecord";
                return await connection.QueryAsync<ClockingRecord>(query);
            }
        }

    }
}