using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyBeer.Models;

namespace RateMyBeer.Controllers
{
    public class ReviewController : Controller
    {
        public static List<WriteReviewViewModel> reviewList = new List<WriteReviewViewModel>();

        public ActionResult WriteReview(int beerId)
        {
            DAO da = new DAO();
            WriteReviewViewModel review = new WriteReviewViewModel();

            review.Beers = da.ReturnBeerByID(beerId);

            return View(review);
        }

        
        public ActionResult CreateReview(WriteReviewViewModel review, int beerId)
        {
            DAO da = new DAO();
            int count = 0;
            if (ModelState.IsValid)
            {
                review.Reviews.BeerID = beerId;
                review.Reviews.UserName = @Session["memberName"].ToString();
                count = da.InsertReview(review);

                if (count > 0)
                {
                    reviewList.Add(review);
                    da.InsertRating(beerId);

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
    }
}