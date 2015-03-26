using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  

namespace Portal_Kulinarny.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        public int AuthorId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public DateTime? AddDate { get; set; }
        public string FilePathOnDisk { get; set; }
    }
}