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
            ctx.Questions.Add(new Question
            {
                Description = "Cum aleg o placa video?",
                
            }) ;
           
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}