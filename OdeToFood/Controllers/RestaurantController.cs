using OdeToFood_Data.Models;
using OdeToFood_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        // GET: Restaurant/Details/ID

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // GET: Restaurant/Edit/ID
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have successfully Updated the Restaurant.";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        //GET: Restaurant/Delete/ID
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            var tempstring = db.Get(id).Name;
            db.Delete(id);
            TempData["Message"] = $"{tempstring} has been Successfully Deleted";
            return RedirectToAction("Index");
        }
    }
}