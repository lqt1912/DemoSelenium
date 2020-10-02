using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoSelenium.Models
{
    public partial class Customer
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Password")]
        public string Password { get; set; }
        public DateTime? Dob { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public string Phone { get; set; }

        public Guid Id { get; set; }
    }
}
