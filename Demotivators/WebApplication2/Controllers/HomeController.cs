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
			int numberOfRecentItems = 5;
			var sortedItems = GetRecentItems(numberOfRecentItems);
			return View(await sortedItems.ToListAsync());
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

		private IQueryable<Item> GetRecentItems(int howMany)
		{
			DbEntities context = new DbEntities();
			var items = context.Item.Include(i => i.AspNetUsers);
			var sortedItems = items.OrderByDescending(i => i.Date_Creation)
			.Take(howMany);
			return sortedItems;
		}

		private IEnumerable<Item> GetTopCreators(int howMany)
		{
		DbEntities context = new DbEntities();
			var items = context.Item.Include(i => i.AspNetUsers);
			IEnumerable<IGrouping<string, Item>> outerSequence = items.GroupBy(i => i.AspNetUsersId);
			var sortedGroups = outerSequence.OrderByDescending(g => g.Count())
			.Take(howMany);
			List<Item> itemList = new List<Item>();					
			foreach (IGrouping<string, Item> keyGroupSequence in sortedGroups)
			{
				itemList.Add(keyGroupSequence.First());
			}
			return itemList;
			}
		

    }
}