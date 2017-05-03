using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RateMyBeer.Models
{
    public class Member
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is missing")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters are allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is missing")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is missing")]
        [StringLength(15, ErrorMessage = "Password must contain 6 to 15 characters",
            MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is missing")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}