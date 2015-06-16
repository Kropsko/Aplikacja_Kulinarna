using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_Kulinarny.Models
{
    public class Vote
    {
        public int VoteID { get; set; }
        public int VoteForID { get; set; }
        public string UserName { get; set; }
        public int VoteScore { get; set; }
    }
}