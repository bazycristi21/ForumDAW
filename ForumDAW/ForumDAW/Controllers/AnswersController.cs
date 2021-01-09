using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
using System.Data.Entity;
namespace ForumDAW.Controllers
{
    public class AnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Answers
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult New()
        {
            Answer answer = new Answer();
            return View(answer);
        }
        [HttpPost]
        public ActionResult Create(int QuestionId, Answer answerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    answerRequest.PublishTime = DateTime.Now;
                    answerRequest.QuestionId = QuestionId;
                    db.Answers.Add(answerRequest);
                    db.SaveChanges();
                    return RedirectToAction("AllQuestions", "Questions");
                }
                return View(answerRequest);
            }
            catch (Exception e)
            {
               return View(answerRequest);
            }
            return View();
        }
    }
}