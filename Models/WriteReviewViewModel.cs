using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyBeer.Models
{
    public class WriteReviewViewModel
    {
       public Review Reviews { get; set; }

       public Beer Beers { get; set; }
                
    }
}