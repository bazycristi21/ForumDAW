﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ForumDAW.Models;

namespace ForumDAW.DataAccessLayer
{
    public class DbCtx : DbContext
    {
        public DbCtx() : base("ForumDB")
        {

            //Database.SetInitializer<DbCtx>(new Initp());
            //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
        }


    }
}