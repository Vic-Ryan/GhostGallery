using GhostGallery.Models;
using GhostGallery.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostGallery.WebMVC.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        // GET: Ghost
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService();
            var model = service.GetLocations();
            return View(model);
        }

        // GET: Location
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateLocationService();

            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Location successfully added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Location could not be added");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model = new LocationEdit
            {
                LocationId = detail.LocationId,
                Name = detail.Name,
                Address = detail.Address,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Does Not Match");
                return View(model);
            }

            var service = CreateLocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "Location successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Location could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateLocationService();

            service.DeleteLocation(id);

            TempData["SaveResult"] = "Location successfully deleted.";

            return RedirectToAction("Index");
        }

        private LocationService CreateLocationService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService();
            return service;
        }
    }
}