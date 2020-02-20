using System;
using System.ComponentModel.DataAnnotations;

namespace BlogMvcApp.DLL.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MinLength(5)]
        public string Text { get; set; }
        [Required]
        [Range(0, 5)]
        public int Mark { get; set; }
        public virtual Article Article { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public virtual BlogUser BlogUser { get; set; }
        public string BlogUserId { get; set; }
    }
}