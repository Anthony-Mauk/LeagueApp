using LeagueApp.Data;
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
    public class PlayerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Player
        public ActionResult Index()
        {
            //var model = new PlayerListItem[0];
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new PlayerService(userId);
            var service = CreatePlayerService();
            var model = service.GetPlayers();
            return View(model);
        }

        public ActionResult Create()
        {
            //viewbag.teamid = ?? General Store
            ViewBag.TeamId = new SelectList(_db.Teams.ToList(), "TeamId", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            //if (model.Team.)

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var service = CreatePlayerService();

            if (service.CreatePlayer(model))
            {
                TempData["SaveResult"] = "Your player was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Player could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {

            ViewBag.TeamId = new SelectList(_db.Teams.ToList(), "TeamId", "Name");

            var service = CreatePlayerService();
            var detail = service.GetPlayerById(id);
            var model =
                new PlayerEdit
                {
                    PlayerId = detail.PlayerId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    ParentEmail = detail.ParentEmail,
                    TeamId = detail.TeamId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlayerService();

            if (service.UpdatePlayer(model))
            {
                TempData["SaveResult"] = "Your player was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your player could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlayerService();
            var model = svc.GetPlayerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlayerService();

            service.DeletePlayer(id);

            TempData["SaveResult"] = "Your player was deleted";

            return RedirectToAction("Index");
        }

        private IPlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(userId);
            return service;
        }
    }
}
