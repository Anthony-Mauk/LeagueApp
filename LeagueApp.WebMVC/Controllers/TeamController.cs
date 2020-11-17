using LeagueApp.Models;
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
            var model = new TeamListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}