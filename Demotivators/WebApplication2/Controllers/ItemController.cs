using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


namespace WebApplication2.Controllers
{
	[Authorize]
    public class ItemController : Controller
    {
        private DbEntities db = new DbEntities();

        // GET: Item
        public async Task<ActionResult> Index()
        {
//add
			string CurrentUserId = User.Identity.GetUserId();
            var items = db.Item
			.Include(i => i.AspNetUsers)
			.Where(i => i.AspNetUsersId == CurrentUserId);
            return View(await items.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
//add
            //ViewBag.AspNetUserId = User.Identity.GetUserId();
			ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name_Item,Date_Creation,Url_Img_Original,Url_Img_Done_Item,Header_Text,Text,AspNetUsersId")] Item item)
        {
            if (ModelState.IsValid)
            {
//add
				item.AspNetUsersId = User.Identity.GetUserId();
				item.Date_Creation = DateTime.Now;
                db.Item.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsersId = User.Identity.GetUserId();
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AspNetUsersId = User.Identity.GetUserId();
			ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", item.AspNetUsersId);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name_Item,Date_Creation,Url_Img_Original,Url_Img_Done_Item,Header_Text,Text,AspNetUsersId")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
//add
            //ViewBag.AspNetUsersId = User.Identity.GetUserId();
			ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", item.AspNetUsersId);
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Item.FindAsync(id);
            db.Item.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
