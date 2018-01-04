using Shortner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shortner.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async System.Threading.Tasks.Task<ActionResult> Index(string id = null)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                return View();

            var urlItem = await db.UrlItems.FindAsync(id);
            if (urlItem == null)
            {
                return HttpNotFound();
            }

            string link = urlItem.Link;
            return Redirect(link);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}