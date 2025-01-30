using Clocking.App.Models;
using System;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public class ClockingRecordsRepository : IClockingRecordsRepository
    {
        public Task CreateRecord(ClockingRecord record)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecord(ClockingRecord record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(int employeeID)
        {
            throw new NotImplementedException();
        }

        public Task GetRecord(int employeeID)
        {
            throw new NotImplementedException();
        }

    }
}