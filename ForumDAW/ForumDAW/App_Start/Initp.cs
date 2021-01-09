using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForumDAW.Models;

namespace ForumDAW.DataAccessLayer
{
    public class Initp : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext ctx)
        {
            List<ApplicationUser> Users = ctx.Users.ToList();
            ctx.Questions.Add(new Question
            {
                Description = "Cum aleg o placa video?",
                Id = 1
            });
            ctx.Answers.Add(new Answer
            {
                Description = "Nvidia ftw bro.",
                QuestionId = 1,
                Id = 1
            }) ;
            ctx.Answers.Add(new Answer
            {
                Description = "Seria 6000 amd varule.",
                QuestionId = 1,
                Id = 2
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}