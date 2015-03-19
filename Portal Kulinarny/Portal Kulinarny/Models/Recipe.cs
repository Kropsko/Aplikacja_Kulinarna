using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_Kulinarny.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public List<Comment> Comments { get; set; }
    }
}