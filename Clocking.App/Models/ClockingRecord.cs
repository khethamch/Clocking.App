using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clocking.App.Models
{
    public class ClockingRecord
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}