using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;
using Microsoft.AspNet.Identity;

namespace BucketList.Controllers
{
    [Authorize]
    public class MyListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        // GET: MyLists
        public ActionResult Index()
        {
            //var us = User.Identity.Name;
            //var user = db.Users.FirstOrDefault(x => x.Email == us);
            var list = db.MyLists.Where(x => x.UserId == userId);
            var results = (from r in db.MyLists
                           where r.UserId == userId
                           select r).ToList();



            return View(results);
        }

        // GET: MyLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyList myList = db.MyLists.Find(id);
            if (myList == null)
            {
                return HttpNotFound();
            }
            return View(myList);
        }

        // GET: MyLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Goals,DateCreated")] MyList myList)
        {
            if (ModelState.IsValid)
            {
               
                var newr = myList;
                newr.DateCreated = DateTime.Now.ToString("MM/dd/yyyy");
                newr.UserId = userId;
                db.MyLists.Add(newr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myList);
        }

        // GET: MyLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyList myList = db.MyLists.Find(id);
            if (myList == null)
            {
                return HttpNotFound();
            }
            return View(myList);
        }

        // POST: MyLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Goals,Checked,DateAccomplished, DateCreated")] MyList myList)
        {
            if (ModelState.IsValid)
            {
                var newr = myList;
                newr.UserId = userId;
                newr.DateCreated = DateTime.Now.ToString("MM/dd/yyyy");

                db.MyLists.Add(newr);
                db.Entry(myList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myList);
        }

        // GET: MyLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyList myList = db.MyLists.Find(id);
            if (myList == null)
            {
                return HttpNotFound();
            }
            return View(myList);
        }

        // POST: MyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyList myList = db.MyLists.Find(id);
            db.MyLists.Remove(myList);
            db.SaveChanges();
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
