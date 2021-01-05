using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAW.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}