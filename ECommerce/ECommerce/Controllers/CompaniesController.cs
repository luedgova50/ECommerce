namespace ECommerce.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using ECommerce.Models;
    using WebECommerce.Models;
    public class CompaniesController : Controller
    {
        private WebECommerceContext db = new WebECommerceContext();

        // GET: Companies
        public ActionResult Index()
        {
            var companies = 
                db.Companies.Include(c => c.City).Include(c => c.State);

            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CityId = 
                new SelectList(db.Cities, "CityId", "NameCity");

            ViewBag.StateId = 
                new SelectList(db.State, "StateId", "NameState");

            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CityId = 
                new SelectList(db.Cities, "CityId", "NameCity", company.CityId);

            ViewBag.StateId = 
                new SelectList(db.State, "StateId", "NameState", company.StateId);

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = 
                new SelectList(db.Cities, "CityId", "NameCity", company.CityId);

            ViewBag.StateId = 
                new SelectList(db.State, "StateId", "NameState", company.StateId);

            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CityId = 
                new SelectList(db.Cities, "CityId", "NameCity", company.CityId);

            ViewBag.StateId = 
                new SelectList(db.State, "StateId", "NameState", company.StateId);

            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var company = db.Companies.Find(id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = db.Companies.Find(id);

            db.Companies.Remove(company);

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
