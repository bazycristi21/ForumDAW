using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
using Microsoft.AspNet.Identity;

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
        [Authorize]
        [HttpGet]
        public ActionResult New()
        {
            Question question = new Question();
            return View(question);
        }
        [Authorize]
        [HttpPost]
        
        public ActionResult Create(Question questionRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionRequest.PublishTime = DateTime.Now;
                    questionRequest.UserId = User.Identity.GetUserId();
                    db.Questions.Add(questionRequest);
                    db.SaveChanges();
                    return RedirectToAction("AllQuestions");
                }
                return View("New",questionRequest);
            }
            catch (Exception e)
            {
                return View(questionRequest);
            }
        }
        public ActionResult AllQuestions()
        {
            List<ApplicationUser> users = db.Users.ToList();

            List<Question> questions = db.Questions.ToList();
            foreach(var q in questions)
            {
                q.User = users.FirstOrDefault(u => u.Id == q.UserId);
            }
            List<Answer> answers = db.Answers.ToList();
            foreach (var a in answers)
            {
                a.User = users.FirstOrDefault(u => u.Id == a.UserId);
            }
            ViewBag.questions = questions;
            ViewBag.answers = answers;
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Question ans = db.Questions.Find(id);
                if (ans == null)
                {
                    return HttpNotFound("Could't find it, id " + id.ToString());
                }
                return View(ans);
            }
            return HttpNotFound("Id is null");
        }
        [Authorize]
        [HttpPut]
        public ActionResult ChangeContent(Question questionRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Question ans = db.Questions.FirstOrDefault(b => b.Id.Equals(questionRequest.Id));
                    if (TryUpdateModel(ans))
                    {
                        ans.Description = questionRequest.Description;

                        db.SaveChanges();
                    }
                    return RedirectToAction("AllQuestions", "Questions");

                }
                return View(questionRequest);
            }
            catch (Exception e)
            {
                return View(questionRequest);
            }

        }
        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Question q = db.Questions.Find(id);
            if (q != null)
            {
                List<Answer> answers = db.Answers.ToList();
                foreach(var ans in answers)
                {
                    if(ans.QuestionId == q.Id)
                    {
                        db.Answers.Remove(ans);
                    }
                }
                db.Questions.Remove(q);
                db.SaveChanges();
                return RedirectToAction("AllQuestions", "Questions");
            }
            return HttpNotFound("Couldn't find it, id: " + id.ToString());
        }
    }
}