﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clocking.App.Models
{
    public class EmployeeLeave
    {
        public int EmployeeID { get; set; }
        public string LeaveType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}


    }
}