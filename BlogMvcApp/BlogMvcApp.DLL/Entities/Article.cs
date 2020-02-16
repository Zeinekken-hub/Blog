using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogMvcApp.DLL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(500)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }


        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}