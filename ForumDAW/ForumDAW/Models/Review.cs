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
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }
        public Rating Rating { get; set; }
        public DateTime PublishTime { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}