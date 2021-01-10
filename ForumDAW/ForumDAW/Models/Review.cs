using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ForumDAW.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}