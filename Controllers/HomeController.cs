using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RateMyBeer.Models;
using System.Data;
using System.IO;
using PagedList;

namespace RateMyBeer.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        static DataSet ds;
        static DataTable dt;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Breweries()
        {
            ViewBag.Message = "Breweries";

            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            ViewBag.Message = "Contact Us";
            if (System.IO.File.Exists(Server.MapPath(@"~/messages.xml")))
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath(@"~/messages.xml"));
                dt = ds.Tables[0];
            }
            else
            {
                ds = new DataSet("messages");
                dt = new DataTable("message");
               
                dt.Columns.Add("name");
                dt.Columns.Add("email");
                dt.Columns.Add("subject");
                dt.Columns.Add("message");
                ds.Tables.Add(dt);
            }
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(ContactForm message)
        {


            if (ModelState.IsValid)
            {
                //cerating a new row in DataTable dt
                DataRow row = dt.NewRow();
                //adding data to the new row
                row["name"] = message.Name;
                row["subject"] = message.Subject;
                row["message"] = message.Message;
                row["email"] = message.Email;
                //adding new row to the rows of datatable dt
                dt.Rows.Add(row);
                //writing to XML with the given filename in the current directory
                ds.WriteXml(Server.MapPath(@"~/messages.xml"));
                ViewData["message"] = "Your Message was sent! The Team at Rate My Beer Will Be back To You Soon!";
                return View();
            }
            else
                return View("Index", message);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            DAO dao = new DAO();
            int count;
            if (ModelState.IsValid)
            {
                count = dao.InsertMember(member);
                if (count > 0)
                {
                    ViewData["message"] = "Thanks! You have successfully registered to RateMyBeer";
                }
                else ViewData["message"] = "Error: " + dao.message;
                return View("Message");
            }

            else return View("Register");
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            DAO dao = new DAO();
            Member member = new Member();
            if (ModelState.IsValid)
            {
                member.Email = login.Email;
                member.Password = login.Password;
                member.UserName = dao.CheckLogin(member);

                Session.Add("memberName", member.UserName);
                if (Session["memberName"] == null)
                {
                    ViewData["message"] = "Error: " + dao.message;

                    return View("Message");
                }

                return RedirectToAction("Index");

            }
            else return View("Login");


            return View();
        }

        public ActionResult LogOff()
        {

            Session.Clear();
            return RedirectToAction("Index");
        }

        public static List<Brewery> breweryList = new List<Brewery>();

        // GET: Brewery
        public ActionResult AllBrewerys(int page = 1, int pageSize = 9)
        {
            DAO da = new DAO();
            List<Brewery> list = da.ShowAllBrewerys();
            PagedList<Brewery> model = new PagedList<Brewery>(list, page, pageSize);

            return View(model); // return is now an IEnumerable<T> in paginated form through the extensions provided by the PagedList package
        }

        public ActionResult SingleBrewery(string breweryName, int page = 1, int pageSize = 9)
        {
            List<Beer> individualBrewery = new List<Beer>();

            DAO da = new DAO();
            individualBrewery = da.ReturnBreweryByName(breweryName);
            PagedList<Beer> pagedSearchResult = new PagedList<Beer>(individualBrewery, page, pageSize);

            return View("SingleBrewery", pagedSearchResult);

        }

    }
}