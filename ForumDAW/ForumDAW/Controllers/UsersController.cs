using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAW.Models;
namespace ForumDAW.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.UsersList = ctx.Users.OrderBy(u => u.UserName).ToList();
            return View();
        }
    }
}