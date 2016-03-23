using BucketList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucketList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Dont wait until it is too late.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get in touch";

            return View();
        }

        
        public ActionResult IndexTop()
        {
            var tg = (from t in db.TopGoals
                      select t).ToList();


            return View(tg);

        }

        public ActionResult ShareList()
        {
            return View(db.ShareIdeas.ToList());

        }
        // GET: ShareIdeas/Create
        public ActionResult CreateShareList()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShareList([Bind(Include = "Id,ShareIdeas,Comments")] ShareIdea shareIdea)
        {
            if (ModelState.IsValid)
            {
                db.ShareIdeas.Add(shareIdea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shareIdea);
        }

    }
}