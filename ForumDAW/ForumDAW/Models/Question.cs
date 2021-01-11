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
        [MinLength(5,ErrorMessage = "Lungimea minima este de 5 caractere")]
        [MaxLength(300, ErrorMessage = "Lungimea maximaeste de 300 caractere")]
        [ValidB]
        public string Description { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}