using GhostGallery.Models.Event;
using GhostGallery.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GhostGallery.WebMVC.Controllers
{
    public class EventController : Controller
    {
        // GET: Ghost
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventServices(userId);
            var model = service.GetEvents();
            return View(model);
        }

        // GET: Location
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Event successfully added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Event could not be added");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model = new EventEdit
            {
                EventId = detail.EventId,
                EventDate = detail.EventDate,
                Ghost = detail.Ghost,
                Description = detail.Description,
                Equipment = detail.Equipment
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Does Not Match");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Event successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Event could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocation(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Event successfully deleted.";

            return RedirectToAction("Index");
        }

        private EventServices CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventServices(userId);
            return service;
        }
    }
}