using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.App_LocalResources;
using System.Data;
using System.Data.Entity;
using System.Net;
using WebApplication2;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication2.Models;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {      
        public async Task<ActionResult> Index()
         {
			DbEntities context = new DbEntities();
            var items = context.Item.Include(i => i.AspNetUsers);
			return View(await items.ToListAsync());
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