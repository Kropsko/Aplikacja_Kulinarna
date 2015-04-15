using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace Portal_Kulinarny.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Display(Name = "Autor")]
        public string AuthorName { get; set; }

        [Display(Name = "Nazwa dania")]
        [Required(ErrorMessage="Nazwa dania jest wymagana")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "Czas przygotowania jest wymagany")]
        [Range(1, 960, ErrorMessage = "Niepoprawny czas przygotowania")]
        [Display(Name = "Czas przygotowania")]
        public int PreparationTime { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Image { get; set; }

        [Display(Name = "Treść przepisu")]
        public string Content { get; set; }

        [Display(Name = "Średnia ocen")]
        public double AverageGrade { get; set; }

        [Display(Name = "Lista składników")]
        public List<Ingredient> Ingredients { get; set; }

        [Display(Name = "Komentarze")]
        public List<Comment> Comments { get; set; }
    }
}