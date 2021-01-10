using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ForumDAW.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }
       
        public DateTime PublishTime { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}