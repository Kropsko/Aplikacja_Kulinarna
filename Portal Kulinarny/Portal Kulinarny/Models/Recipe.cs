using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Portal_Kulinarny.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Display(Name = "Autor")]
        public string AuthorName { get; set; }

        [Display(Name = "Nazwa dania")]
        [Required(ErrorMessage="Nazwa dania jest wymagana")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwa musi mieć, przynajmniej 2 znaki i maksymalnie 50 znaków")]
        public string Title { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "Czas przygotowania jest wymagany")]
        [Range(1, 960, ErrorMessage = "Niepoprawny czas przygotowania")]
        [Numeric(ErrorMessage="Czas musi być liczbą")]
        [Display(Name = "Czas przygotowania")]
        public int PreparationTime { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Image { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść przepisu")]
        public string Content { get; set; }

        [Display(Name = "Średnia ocen")]
        public float AverageGrade { get; set; }

        [Display(Name = "Lista składników")]
        public virtual List<Ingredient> Ingredients { get; set; }

        [Display(Name = "Komentarze")]
        public virtual List<Comment> Comments { get; set; }

        public string Votes { get; set; }

    }
}