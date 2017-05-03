using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateMyBeer.Models
{
    public class Brewery
    {
        public int BreweryID { get; set; }

        [Required(ErrorMessage = "A brewery is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A Location is required")]
        public string Location { get; set; }

        public DateTime Founded { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; }
    }
}