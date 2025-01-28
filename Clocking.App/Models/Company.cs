using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clocking.App.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}