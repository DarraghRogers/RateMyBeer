using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RateMyBeer.Models
{
    public class Beer
    {
        public int BeerID { get; set; }

        [Required(ErrorMessage = "A beer name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A beer style is required")]
        public string Style { get; set; }

        public decimal ABV { get; set; }
    
        public decimal Price { get; set; }
        
        public string BreweryName { get; set; }

        public string Description { get; set; }

        public decimal Rating { get; set; }

        public string Image { get; set; }

    }



}