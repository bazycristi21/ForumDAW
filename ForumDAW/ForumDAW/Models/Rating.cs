using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAW.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ReviewId { get; set; }

        public int Grade { get; set; }
    }
    
}