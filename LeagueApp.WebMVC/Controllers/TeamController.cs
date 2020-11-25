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
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            //return View();
            //var model = new TeamListItem[0];
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new TeamService(userId);
            var service = CreateTeamService();
            var model = service.GetTeams();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateTeamService();
            if (service.CreateTeam(model))
            {
                TempData["SaveResult"] = "Your coach was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Coach could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model = new TeamEdit
            {
                TeamId = detail.TeamId,
                Name = detail.Name
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeamId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = "Your team was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your team could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTeamService();
            if (service.DeleteTeam(id))
            {
                TempData["SaveResult"] = "Your team was deleted";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["SaveResult"] = "Your team contains players or coaches, re-assign them before delete";
                return RedirectToAction("Index");
            }

            
        }
        private ITeamService CreateTeamService() //ITeamService return Interface vs. the Service Layer
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(userId);
            return service;
        }
    }
}