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
        public string Text { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        //[NotMapped]
        //CreateDropDownListForTheme
        //Add Validation to Feedback
        //Add migration for themes of articles
        //Create ArticleCreate View
        //Create choice for article theme onclick dropdown list
        //Redesign some new features and delete the oldest
    }
}