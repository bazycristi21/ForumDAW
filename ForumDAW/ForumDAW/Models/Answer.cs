using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ForumDAW.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}