using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ForumDAW.Models;

namespace ForumDAW.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.User);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [Authorize]
        [HttpGet]
        public ActionResult New()
        {
            Review rev = new Review();
            return View(rev);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(int ComponentId, Review reviewRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reviewRequest.PublishTime = DateTime.Now;
                    reviewRequest.ComponentId = ComponentId;
                    reviewRequest.UserId = User.Identity.GetUserId();
                    db.Reviews.Add(reviewRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Reviews");
                }
                return View(reviewRequest);
            }
            catch (Exception e)
            {
                return View(reviewRequest);
            }
        }
        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Review rev = db.Reviews.Find(id);
                if (rev == null)
                {
                    return HttpNotFound("Could't find it, id " + id.ToString());
                }
                return View(rev);
            }
            return HttpNotFound("Id is null");
        }
        [Authorize]
        [HttpPut]
        public ActionResult ChangeContent(Review reviewRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Review rev = db.Reviews.FirstOrDefault(b => b.Id.Equals(reviewRequest.Id));
                    if (TryUpdateModel(rev))
                    {
                        rev.Description = reviewRequest.Description;

                        db.SaveChanges();
                    }
                    return RedirectToAction("AllQuestions", "Questions");

                }
                return View(reviewRequest);
            }
            catch (Exception e)
            {
                return View(reviewRequest);
            }

        }
        // GET: Reviews/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
