using Clocking.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocking.App.Repository
{
    public interface IClockingRecordsRepository
    {
        Task CreateRecord(ClockingRecord record);
        Task UpdateRecord(ClockingRecord record);
        Task DeleteRecord(int employeeID);
        Task GetRecord(int employeeID);
        

    }
}
