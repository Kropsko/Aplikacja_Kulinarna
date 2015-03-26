using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace Portal_Kulinarny.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Display(Name = "Autor")]
        public int AuthorId { get; set; }
        [Display(Name = "Tytul")]
        public string Title { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime? AddDate { get; set; }
        public FilePath Image { get; set; }
        [Display(Name = "Tresc")]
        public string Content { get; set; }
        [Display(Name = "Oceny")]
        public double Rating { get; set; }
        public List<Comment> Comments { get; set; }
    }
}