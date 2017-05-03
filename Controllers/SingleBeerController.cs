using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyBeer.Models;

namespace RateMyBeer.Controllers
{
    public class SingleBeerController : Controller
    {
        public static List<Review> reviewList = new List<Review>();

        // GET: SingleBeer
        public ActionResult SingleBeer(int beerId)
        {
            //ViewBag.Message = "Single Beer";
            ViewModelSingleBeer model = new ViewModelSingleBeer();

            DAO da = new DAO();
            model.Beers = da.ReturnBeerByID(beerId);
            model.Reviews = da.ReturnReviewByBeerID(beerId);

            decimal rating = da.ReturnRating(beerId);
            model.Beers.Rating = rating;
            return View(model);
        }

        public ActionResult WriteReview(int beerId)
        {
            Review review = new Review();
            review.BeerID = beerId;
             
            return View(review);
        }

        //public ActionResult ReturnRating(int beerId)
        //{
        //    DAO da = new DAO();
        //    decimal rating = da.ReturnRating(beerId);



        //}

    }
}