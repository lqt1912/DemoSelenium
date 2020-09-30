using System;
using System.Collections.Generic;

namespace DemoSelenium.Models
{
    public partial class Customer
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public string Phone { get; set; }
        public Guid Id { get; set; }
    }
}
