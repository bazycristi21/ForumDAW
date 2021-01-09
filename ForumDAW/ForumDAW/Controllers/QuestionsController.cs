using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
namespace ForumDAW.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Questions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Random()
        {
            var question = new Question() { Description = "Cum aleg o placa video?" };

            return View(question);
        }
        [HttpGet]
        public ActionResult New()
        {
            Question question = new Question();
            return View(question);
        }
        [HttpPost]
        public ActionResult Create(Question questionRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionRequest.PublishTime = DateTime.Now;
                    db.Questions.Add(questionRequest);
                    db.SaveChanges();
                    return RedirectToAction("AllQuestions");
                }
                return View(questionRequest);
            }
            catch (Exception e)
            {
                return View(questionRequest);
            }
        }
        public ActionResult AllQuestions()
        {
            List<Question> questions = db.Questions.ToList();
            List<Answer> answers = db.Answers.ToList();
            //AllQuestionsAnswers A = new AllQuestionsAnswers { Questions = questions, Answers = answers };
            ViewBag.questions = questions;
            ViewBag.answers = answers;
            return View();
        }
    }
}