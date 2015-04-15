using System;
using System.ComponentModel.DataAnnotations;
namespace Portal_Kulinarny.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int RecipeId { get; set; }
        [Display(Name = "Autor")]
        public int AuthorName { get; set; }
        [Display(Name = "Treść")]
        [Required(ErrorMessage="Komentarz musi zawierać treść")]
        public string Content { get; set; }
        public DateTime AddDate { get; set; }
    }
}