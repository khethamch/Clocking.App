using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clocking.App.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
    }
}