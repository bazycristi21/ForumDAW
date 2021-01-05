using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForumDAW.Models;

namespace ForumDAW.DataAccessLayer
{
    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        protected override void Seed(DbCtx context)
        {
            User u1 = new User
            {
                EmailAddress = "bazy_cristi_21@yahoo.com",
                FirstName = "Bazavan",
                LastName = "Cristian",
                Id = 1
            };
            User u2 = new User
            {
                EmailAddress = "a@yahoo.com",
                FirstName = "Popescu",
                LastName = "Ionescu",
                Id = 2
            };
            Question q1 = new Question
            {
                Description = "Cum aleg o placa video?",
                UserId = 1,
                Id = 1
            };
            Question q2 = new Question
            {
                Description = "Am procesor AMD fara cooler si ajunge la 120 de grade. E in regula?",
                UserId = 2,
                Id = 2
            };
            Answer a1 = new Answer
            {
                Id = 1,
                QuestionId = 2,
                UserId = 1,
                Description = "E in regula, stai chill."
            };
            context.Users.Add(u1);
            context.Users.Add(u2);
            context.Questions.Add(q1);
            context.Questions.Add(q2);
            context.Answers.Add(a1);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}