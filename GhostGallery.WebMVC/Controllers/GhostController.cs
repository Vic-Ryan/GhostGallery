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


        private GhostService CreateGhostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GhostService(userId);
            return service;
        }
    }
}