using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyBeer.Models;
using PagedList;

namespace RateMyBeer.Controllers
{
    public class BeerController : Controller
    {
        public static List<Beer> beerList = new List<Beer>();

        // GET: Beer
        public ActionResult AddBeer()
        {            
            return View();
        }

        // GET: Beer/Details
        public ActionResult AllBeers(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllBeers();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);
            
            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }
   
        public ActionResult AllAles(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllAles();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }
        public ActionResult AllIpas(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllIpas();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }
        public ActionResult AllStouts(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllStouts();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }
        public ActionResult AllBlondes(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllBlondes();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }
        public ActionResult AllTopRated(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Beer> list = da.ShowAllTopRated();
            PagedList<Beer> model = new PagedList<Beer>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }


        // POST: Beer/Create
        [HttpPost]
        public ActionResult Create(Beer beer, HttpPostedFileBase file)
        {
            DAO da = new DAO();
            int count = 0;
            if (ModelState.IsValid)
            {
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/

                filename = Guid.NewGuid() + filename;
                file.SaveAs(Server.MapPath("~/img/" + filename));
                string filepathtosave = "~/img/" + filename;
                beer.Image = filepathtosave;

                count = da.Insert(beer);
                if (count > 0)
                {
                    beerList.Add(beer);
                    ViewData["message"] = "Record included successfully";
                }
                else ViewData["message"] = da.message;

            }
            else
            {
                ViewData["message"] = "Error,try again";

            }

            return View("../Home/Index", ViewData["message"]);
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
