using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shortner.Models;

namespace Shortner.Controllers
{
    [Authorize]
    public class UrlController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Url
        public async Task<ActionResult> Index()
        {
            return View(await db.UrlItems.ToListAsync());
        }

        // GET: Url/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlItem urlItem = await db.UrlItems.FindAsync(id);
            if (urlItem == null)
            {
                return HttpNotFound();
            }
            return View(urlItem);
        }

        // GET: Url/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Url/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Link")] UrlItem urlItem)
        {
            if (ModelState.IsValid)
            {
                db.UrlItems.Add(urlItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(urlItem);
        }

        // GET: Url/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlItem urlItem = await db.UrlItems.FindAsync(id);
            if (urlItem == null)
            {
                return HttpNotFound();
            }
            return View(urlItem);
        }

        // POST: Url/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Link")] UrlItem urlItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urlItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(urlItem);
        }

        // GET: Url/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlItem urlItem = await db.UrlItems.FindAsync(id);
            if (urlItem == null)
            {
                return HttpNotFound();
            }
            return View(urlItem);
        }

        // POST: Url/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UrlItem urlItem = await db.UrlItems.FindAsync(id);
            db.UrlItems.Remove(urlItem);
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
