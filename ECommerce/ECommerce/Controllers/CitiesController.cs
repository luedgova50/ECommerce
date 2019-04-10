namespace ECommerce.Controllers
{
    using ECommerce.Classes;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using WebECommerce.Models;

    public class CitiesController : Controller
    {
        private WebECommerceContext db = new WebECommerceContext();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = 
                db.Cities.Include(c => c.State);

            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            

            ViewBag.StateId = 
                new SelectList(
                    ComBoxHelpers.
                    GetStates(), 
                    "StateId", 
                    "NameState");

            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = 
                new SelectList(
                    ComBoxHelpers.
                    GetStates(),
                "StateId", 
                "NameState", 
                city.StateId);

            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.StateId = 
                new SelectList(
                    ComBoxHelpers.
                    GetStates(), 
                "StateId", 
                "NameState", 
                city.StateId);

            return View(city);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = 
                    EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.StateId = 
                new SelectList(
                    ComBoxHelpers.
                    GetStates(), 
                    "StateId", 
                    "NameState", 
                    city.StateId);

            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var city = db.Cities.Find(id);

            db.Cities.Remove(city);


            try
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.
                    InnerException != null &&
                    ex.InnerException.
                    InnerException.Message.
                    Contains("REFERENCE"))
                {
                    ModelState.
                        AddModelError(
                        string.Empty,
                        "The Selected Record can't be Deleted, "
                        + " Because it Already Contains Related Records");
                }
                else
                {
                    ModelState.
                        AddModelError(
                        string.Empty,
                        ex.Message);
                }
            }

            return View(city);

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
