using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HoidayResorts.DataContexts;
using HoidayResorts.Data_Entities;
using HoidayResorts.Models;

using PagedList;

namespace HoidayResorts.Controllers
{
    public class ResortsController : Controller
    {
        private HolidayResortsDb _db = new HolidayResortsDb();

        //Index
        public ActionResult Index(int? page, string searchTerm = null)
        {
            var pageNumber = page ?? 1;

            var model =
                _db.Resorts
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Where(r => searchTerm == null ||

                                r.Country.StartsWith(searchTerm) ||
                                r.Name.StartsWith(searchTerm) ||
                                r.Location.StartsWith(searchTerm) ||
                                r.Country.Contains(searchTerm) ||
                                r.Name.Contains(searchTerm) ||
                                r.Location.Contains(searchTerm))
                    .Select(r => new ResortViewModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Location = r.Location,
                        Country = r.Country,
                        Description = r.Description,
                        Reviews = r.Reviews,
                        CheapestRoom = r.CheapestRoom,
                        ImageUrl = r.ImageUrl,
                        CountOfReviews = r.Reviews.Count(),
                        OverallRating = r.Reviews.Average(review => review.Rating)
                    })
                    .ToPagedList(pageNumber, 3);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ResortList", model);
            }

            return View(model);
        }

        //Search Field Autocomplete
        public JsonResult Autocomplete(string term)
        {
            var countryFound =
                _db.Resorts
                    .Where(r => r.Country.StartsWith(term))
                    .Take(1)
                    .Select(r => new { label = r.Country });

            var locationFound =
                _db.Resorts
                    .Where(r => r.Location.StartsWith(term))
                    .Take(1)
                    .Select(r => new { label = r.Location });

            var resortsFound = 
                _db.Resorts
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new { label = r.Name });

            var model = countryFound.Concat(locationFound).Concat(resortsFound);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Resort Details 
        public ViewResult Details(int id)
        {
            var resort = _db.Resorts
                .Where(r => r.Id == id)
                .Select( r=> new ResortViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Location = r.Location,
                    Country = r.Country,
                    Reviews = r.Reviews,
                    Description = r.Description,
                    CheapestRoom = r.CheapestRoom,
                    ImageUrl = r.ImageUrl,
                    CountOfReviews = r.Reviews.Count(),
                    OverallRating = r.Reviews.Average(review => review.Rating)
                })
                .First();

            return View(resort);
        }

        //Create New Resort 
        //GET
        public ViewResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country,Location,CheapestRoom,ImageUrl,Description")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                _db.Resorts.Add(resort);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resort);
        }

        //Edit Resort
        //GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = _db.Resorts.Find(id);
            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country,Location,CheapestRoom,ImageUrl,Description")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(resort).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resort);
        }

        //Delete Resort 
        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resort resort = _db.Resorts.Find(id);

            if (resort == null)
            {
                return HttpNotFound();
            }
            return View(resort);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resort resort = _db.Resorts.Find(id);

            _db.Resorts.Remove(resort);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Dispose database
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
