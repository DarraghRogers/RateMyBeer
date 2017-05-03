using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RateMyBeer.Models
{
    public class ContactForm

    {
        [Required(ErrorMessage = "Name is required") ]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Words only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must have email")]
        [EmailAddress(ErrorMessage = "Valid email address is required")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Must have subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Must have message")]
        public string Message { get; set; }


    }
}