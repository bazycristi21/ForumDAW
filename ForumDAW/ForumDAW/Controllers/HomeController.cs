using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
namespace ForumDAW.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            List<Question> questions = db.Questions.ToList();
            List<Answer> answers = db.Answers.ToList();
            AllQuestionsAnswers A = new AllQuestionsAnswers { Questions = questions, Answers = answers };
            return View(A);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}