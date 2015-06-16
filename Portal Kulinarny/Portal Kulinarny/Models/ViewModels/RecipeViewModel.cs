using Portal_Kulinarny.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal_Kulinarny.Models.ViewModels
{
    public class CreateRecipeViewModel
    {
        public int RecipeId { get; set; }

        [Display(Name = "Autor")]
        public string AuthorName { get; set; }

        [Display(Name = "Nazwa dania")]
        [Required(ErrorMessage = "Nazwa dania jest wymagana")]
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

        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść przepisu")]
        public string Content { get; set; }

        [Display(Name = "Średnia ocen")]
        public float AverageGrade { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }

        public SelectList UnitNameList { get; set; }
        public CreateRecipeViewModel()
        {
            UnitNameList = Strings.UnitNameList;
        }
    }

    public class NewestRecipesViewModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }

    public class BestRatedViewModel
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public float AverageGrade { get; set; }
    }

    public class RecipeEditViewModels
    {
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwa potrawy musi się składać minimum z 2 znaków, nie może też być dłuższa niż 50 znaków")]
        [Display(Name = "Nazwa")]
        public string Title { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Pole Czas przygotowania jest wymagane")]
        [Display(Name = "Czas przygotowania")]
        [Range(1, 960, ErrorMessage = "Czas przygotowania musi być z zakresu od 1 do 960 minut")]
        public int PreparationTime { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść przepisu")]
        public string Content { get; set; }

        [Display(Name = "Średnia ocen")]
        public float AverageGrade { get; set; }

        [Display(Name = "Lista składników")]
        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }

        public SelectList UnitNameList { get; set; }

        public RecipeEditViewModels()
        {
            UnitNameList = Strings.UnitNameList;
        }


    }
}