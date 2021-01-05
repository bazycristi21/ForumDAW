using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAW.Models
{
    public class AllQuestionsAnswers
    {
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}