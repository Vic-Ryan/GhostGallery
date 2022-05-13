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
    public class GhostController : Controller
    {
        // GET: Ghost
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GhostService(userId);
            var model = service.GetGhosts();
            return View(model);
        }

        // GET: Ghost
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GhostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateGhostService();

            if (service.CreateGhost(model))
            {
                TempData["SaveResult"] = "Ghost successfully added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ghost could not be added");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGhostService();
            var model = svc.GetGhostById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGhostService();
            var detail = service.GetGhostById(id);
            var model = new GhostEdit
            {
                GhostId = detail.GhostId,
                Name = detail.Name,
                LocationId = detail.LocationId,
                Type = detail.Type,
                FirstSighting = detail.FirstSighting,
                Appearance = detail.Appearance,
                Description = detail.Description,
                ThreatLevel = detail.ThreatLevel,
                Powers = detail.Powers
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GhostEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.GhostId != id)
            {
                ModelState.AddModelError("", "Id Does Not Match");
                return View(model);
            }

            var service = CreateGhostService();

            if (service.UpdateGhost(model))
            {
                TempData["SaveResult"] = "Ghost successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ghost could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGhostService();
            var model = svc.GetGhostById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGhost(int id)
        {
            var service = CreateGhostService();

            service.DeleteGhost(id);

            TempData["SaveResult"] = "Ghost successfully deleted.";

            return RedirectToAction("Index");
        }

        private GhostService CreateGhostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GhostService(userId);
            return service;
        }
    }
}