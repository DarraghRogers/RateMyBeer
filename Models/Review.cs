using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RateMyBeer.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "A review title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A rating is required")]
        public decimal Rating { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int BeerID { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "A review body required")]
        public string ReviewBody { get; set; }

    }
}