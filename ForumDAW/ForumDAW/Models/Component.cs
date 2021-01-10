using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDAW.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specifications { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}