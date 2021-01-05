using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAW.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}