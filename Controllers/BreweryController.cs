using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RateMyBeer.Models;

namespace RateMyBeer.Controllers
{
    public class BreweryController : Controller
    {
        public static List<Brewery> breweryList = new List<Brewery>();

        // GET: Brewery
        public ActionResult AllBrewerys(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Brewery> list = da.ShowAllBrewerys();
            PagedList<Brewery> model = new PagedList<Brewery>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }

        public ActionResult SingleBrewery(string breweryName)
        {
            List<Beer> individualBrewery = new List<Beer>();

            DAO da = new DAO();
           individualBrewery =  da.ReturnBreweryByName(breweryName);
            return View(individualBrewery);
            
        }
    }
}