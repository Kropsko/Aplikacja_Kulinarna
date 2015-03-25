using System;
using System.Collections.Generic;

namespace Portal_Kulinarny.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public List<Comment> Comments { get; set; }
    }
}