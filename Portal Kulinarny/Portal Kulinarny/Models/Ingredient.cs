using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal_Kulinarny.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Display(Name = "Nazwa składnika")]
        public string IngredientName { get; set; }
        
        [Display(Name = "ilość")]
        [RegularExpression(@"^\d+[\.\,]{1}\d+|^\d+\/{1}\d+|^\d+\-{1}\d+|^\d+", ErrorMessage = "Niepoprawna ilość, można podać liczbę całkowitą, ułamek zwykły lub dziesiętny")]
        public string Quantity { get; set; }

        [Display(Name = "Jednostka")]
        public string Unit { get; set; }
    }
}