using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal_Kulinarny.Models;

namespace Portal_Kulinarny.Controllers
{
    public class CommentsController : Controller
    {
        readonly RecipeContext db = new RecipeContext();

        [HttpPost]
        [Authorize]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.AddDate = DateTime.Now;
                comment.AuthorName = User.Identity.Name;
                db.Comments.Add(comment);
                db.SaveChanges();

                if (Request.IsAjaxRequest())
                {
                    var comments = db.Comments.Where(p => p.RecipeId == comment.RecipeId).ToList();
                    return PartialView("CommentsList", comments);
                }
            }

            var recipeId = db.Recipes.Single(p => p.RecipeId == comment.RecipeId).RecipeId;
            return RedirectToAction("Details", "Recipes", new { id = recipeId });
        }

        //[CommentOnlyOwnerOrAdminOrEditors]
        public ActionResult Delete(int id)
        {
            var comment = db.Comments.Single(p => p.CommentId == id);           
            try
            {
                db.Comments.Remove(comment);
                db.SaveChanges();

                if (Request.IsAjaxRequest())
                {
                    var comments = db.Recipes.Single(p => p.RecipeId == comment.RecipeId).Comments.ToList();
                    return PartialView("CommentsList", comments);
                }

                return RedirectToAction("Details", "Recipes", new { id = db.Recipes.Single(p => p.RecipeId == comment.RecipeId).RecipeId });
            }
            catch
            {
                return RedirectToAction("Details", "Recipes", new { id = db.Recipes.Single(p => p.RecipeId == comment.RecipeId).RecipeId });
            }
        }
    }
}