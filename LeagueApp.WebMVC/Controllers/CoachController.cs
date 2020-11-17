using LeagueApp.Models;
using LeagueApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueApp.WebMVC.Controllers
{
    [Authorize]
    public class CoachController : Controller
    {
        // GET: Coach
        public ActionResult Index()
        {
            var service = CreateCoachService();
            var model = service.GetCoaches();
            //var model = new CoachListItem[0];
            return View(model);
        }

        private CoachService CreateCoachService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CoachService(userId);
            return service;
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoachCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateCoachService();

            if (service.CreateCoach(model))
            {
                TempData["SaveResult"] = "Your Coach was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Coach could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCoachService();
            var model = svc.GetCoachById(id);

            return View(model);
        }

        public ActionResult Edit(int id) 
        {
            var service = CreateCoachService();
            var detail = service.GetCoachById(id);
            var model =
                new CoachEdit
                {
                    CoachId = detail.CoachId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoachEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CoachId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCoachService();
            if (service.UpdateCoach(model))
            {
                TempData["SaveResult"] = "Your coach was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your coach could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCoachService();
            var model = svc.GetCoachById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCoachService();

            service.DeleteCoach(id);

            TempData["SaveResult"] = "The coach was deleted";

            return RedirectToAction("Index");
        }
    }
}