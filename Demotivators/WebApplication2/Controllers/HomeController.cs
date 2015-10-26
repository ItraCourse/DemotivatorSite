using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.App_LocalResources;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = GlobalRes.Your_application;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = GlobalRes.Your_contact;

            return View();
        }
    }
}