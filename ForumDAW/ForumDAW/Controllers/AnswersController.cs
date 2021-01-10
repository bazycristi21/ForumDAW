using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Web.UI;

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
                    answerRequest.UserId = User.Identity.GetUserId();
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
        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            if(id.HasValue)
            {
                Answer ans = db.Answers.Find(id);
                if(ans == null)
                {
                    return HttpNotFound("Could't find it, id " + id.ToString());
                }
                return View(ans);
            }
            return HttpNotFound("Id is null");
        }
        [HttpPut]
        public ActionResult ChangeContent(Answer answerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Answer ans = db.Answers.FirstOrDefault(b => b.Id.Equals(answerRequest.Id));
                    if (TryUpdateModel(ans))
                    {
                        ans.Description = answerRequest.Description;

                        db.SaveChanges(); 
                    }
                    return RedirectToAction("AllQuestions", "Questions");

                }
                return View(answerRequest);
            }
            catch(Exception e)
            {
                return View(answerRequest);
            }

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Answer ans = db.Answers.Find(id);
            if(ans != null)
            {
                db.Answers.Remove(ans);
                db.SaveChanges();
                return RedirectToAction("AllQuestions", "Questions");
            }
            return HttpNotFound("Couldn't find it, id: " + id.ToString());
        }
       
    }
}