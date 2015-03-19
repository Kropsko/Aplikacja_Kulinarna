using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_Kulinarny.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int RecipeId { get; set; }
        public int AuthorId { get; set; }
        public string Content { get; set; }
    }
}