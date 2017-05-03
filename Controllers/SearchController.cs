using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyBeer.Models;
using PagedList;

namespace RateMyBeer.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchPage()
        {
            return View();
        }


        public ActionResult Search(string searchString, int page = 1, int pageSize = 9)
        {
            // insert strin searchString to DAO object callig search DB function
            List<Beer> searchResult = new List<Beer>();
            DAO da = new DAO();
            searchResult = da.SearchBeer(searchString);
            PagedList<Beer> pagedSearchResult = new PagedList<Beer>(searchResult, page, pageSize);

            return View("SearchResults", pagedSearchResult);
        }
    }
}