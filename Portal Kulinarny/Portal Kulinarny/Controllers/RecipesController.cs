using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal_Kulinarny.Models;
using Portal_Kulinarny.Models.ViewModels;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Portal_Kulinarny.Models.Constants;
using System.Globalization;

namespace Portal_Kulinarny.Controllers
{
    
    public class RecipesController : Controller
    {
        private RecipeContext db = new RecipeContext();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(db.Recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        [Authorize]
        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Recipe recipe, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var uniqueFileName = Guid.NewGuid() + fileName;
                    var absolutePath = Path.Combine(Server.MapPath("~/Images/Uploaded"), uniqueFileName);
                    var relativePath = "~/Images/Uploaded/" + uniqueFileName;
                    file.SaveAs(absolutePath);
                    recipe.Image = relativePath;
                }
                else
                {
                    recipe.Image = "~/Images/Default/No_Photo.jpg";
                }
                recipe.AddDate = DateTime.Now;
                recipe.AuthorName = User.Identity.Name;

                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Ingredients.RemoveRange(recipe.Ingredients);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult NewestRecipes()
        {
            int count = db.Recipes.Count() > 3 ? 3 : db.Recipes.Count();

            var recipes = (from p in db.Recipes
                           orderby p.AddDate descending
                           select p).Take(count).ToList();

            var mv = recipes.Select(u => new NewestRecipesViewModel
            {
                RecipeId = u.RecipeId,
                Title = u.Title,
                Image = u.Image
            }).ToList();

            return PartialView("NewestRecipes", mv);
        }

        public ActionResult BestRated()
        {
            int count = db.Recipes.Count() > 3 ? 3 : db.Recipes.Count();

            var recipes = (from p in db.Recipes
                           orderby p.AverageGrade descending
                           select p).Take(count).ToList();

            var mv = recipes.Select(u => new BestRatedViewModel
            {
                RecipeId = u.RecipeId,
                Title = u.Title,
                Image = u.Image,
                AverageGrade = u.AverageGrade
            }).ToList();

            return PartialView("BestRated", mv);
        }

        public ActionResult IngredientEntryRow()
        {
            ViewBag.UnitNames = Strings.UnitNameList;
            return PartialView("IngredientEditor");
        }

        public ActionResult Search(string search)
        {
            var recipes =
                db.Recipes.Where(
                    a =>
                        a.Title.ToLower().Contains(search.ToLower()) ||
                        a.Ingredients.Any(
                            ingred => ingred.IngredientName.ToLower().Contains(search.ToLower()))).ToList();

            return View(recipes);
        }

        public ActionResult UserRecipes()
        {
            var userRecipes = db.Recipes.Where(a => a.AuthorName == User.Identity.Name).ToList();

            return View(userRecipes);
        }

        public string ValidWordForm(string unitName, string quantity)
        {
            if (quantity.Contains(','))
            {
                quantity = quantity.Replace(",", ".");
            }
            else if (quantity.Contains('/'))
            {
                string[] numbers = quantity.Split('/');
                quantity = (double.Parse(numbers[0]) / double.Parse(numbers[1])).ToString(CultureInfo.InvariantCulture);
            }
            else if (quantity.Contains('-'))
            {
                string[] numbers = quantity.Split('-');
                quantity = double.Parse(numbers[1]).ToString(CultureInfo.InvariantCulture);
            }
            double quantityNumber = double.Parse(quantity, CultureInfo.InvariantCulture);

            string validForm = unitName;
            switch (unitName)
            {
                case "litr":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "litry";
                    else if (quantityNumber >= 5)
                        validForm = "litrów";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "litra";
                    break;

                case "mililitr":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "mililitry";
                    else if (quantityNumber >= 5)
                        validForm = "mililitrów";
                    break;

                case "kilogram":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "kilogramy";
                    else if (quantityNumber >= 5)
                        validForm = "kilogramów";
                    break;

                case "dekagram":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "dekagramy";
                    else if (quantityNumber >= 5)
                        validForm = "dekagramów";
                    break;

                case "gram":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "gramy";
                    else if (quantityNumber >= 5)
                        validForm = "gramów";
                    break;

                case "sztuka":
                    if (Math.Abs(quantityNumber - 1) > 0.00000001 && quantityNumber > 0 && quantityNumber < 5)
                        validForm = "sztuki";
                    else if (quantityNumber >= 5)
                        validForm = "sztuk";
                    break;

                case "plaster":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "plastry";
                    else if (quantityNumber >= 5)
                        validForm = "plastrów";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "plastra";
                    break;

                case "opakowanie":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "opakowania";
                    else if (quantityNumber >= 5)
                        validForm = "opakowań";
                    break;

                case "łyżka":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "łyżki";
                    else if (quantityNumber >= 5)
                        validForm = "łyżek";
                    break;

                case "łyżeczka":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "łyżeczki";
                    else if (quantityNumber >= 5)
                        validForm = "łyżeczek";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "łyżeczeki";
                    break;

                case "szklanka":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "szklanki";
                    else if (quantityNumber >= 5)
                        validForm = "szklanek";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "szklanki";
                    break;

                case "kropla":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "krople";
                    else if (quantityNumber >= 5)
                        validForm = "kropli";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "kropli";
                    break;

                case "kostka":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "kostki";
                    else if (quantityNumber >= 5)
                        validForm = "kostek";
                    else if (quantityNumber > 0 && quantityNumber < 1)
                        validForm = "kostki";
                    break;


                case "szczypta":
                    if (quantityNumber > 1 && quantityNumber < 5)
                        validForm = "szczypty";
                    else if (quantityNumber >= 5)
                        validForm = "szczypt";
                    break;

            }
            return validForm;
        }

        public string ValidMinutesForm(int minutes)
        {
            if (minutes < 100)
            {
                if (minutes == 1)
                    return "minuta";

                if (minutes <= 4)
                    return "minuty";

                if (minutes > 4 && minutes <= 21)
                    return "minut";

                if (minutes > 21)
                {
                    if (minutes % 10 > 4 || minutes % 10 == 0 || minutes % 10 == 1)
                        return "minut";
                    else
                        return "minuty";
                }
            }
            else
            {
                if (minutes == 100 || minutes == 101)
                    return "minut";

                if (minutes <= 104)
                    return "minuty";

                if (minutes > 104 && minutes < 122)
                    return "minut";

                if (minutes > 121)
                {
                    if (minutes % 100 > 4 || minutes % 100 == 0 || minutes % 100 == 1)
                        return "minut";
                    else
                        return "minuty";
                }
            }
            return "minuta";
        }

    }
}
