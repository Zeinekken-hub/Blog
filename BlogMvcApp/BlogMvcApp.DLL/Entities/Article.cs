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
        [MinLength(100)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [Display(Name = "Genre of your article")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}