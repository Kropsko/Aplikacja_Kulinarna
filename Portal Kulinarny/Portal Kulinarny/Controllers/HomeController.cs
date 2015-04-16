using Portal_Kulinarny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Portal_Kulinarny.Controllers
{
    public class HomeController : Controller
    {
        private RecipeContext db = new RecipeContext();

        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}