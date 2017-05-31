using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HoidayResorts.DataContexts;
using HoidayResorts.Data_Entities;

namespace HoidayResorts.Controllers
{
    public class ReviewsController : Controller
    {
        private HolidayResortsDb _db = new HolidayResortsDb();

        //Add New Review
        //GET
        public ViewResult Create(int resortId)
        {
            ViewBag.ResortId = resortId;
            return View();
        }
        //POST
        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Details","Resorts", new {id = review.ResortId});
            }
            return View(review);
        }

        //Edit Review
        //GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _db.Reviews.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Details", "Resorts", new { id = review.ResortId });
            }
            return View(review);
        }

        //Delete Review
        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);

            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = _db.Reviews.Find(id);

            _db.Reviews.Remove(review);
            _db.SaveChanges();
            return RedirectToAction("Details", "Resorts", new {id= review.ResortId});
        }

        //Dispose Database
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}