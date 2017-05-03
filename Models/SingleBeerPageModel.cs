using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RateMyBeer.Models
{
    public class ViewModelSingleBeer
    {
        public List<Review> Reviews { get; set; }

        public Beer Beers { get; set; }
       
    }
}