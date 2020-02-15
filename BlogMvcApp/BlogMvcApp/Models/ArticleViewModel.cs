using System;
using System.Collections.Generic;

namespace BlogMvcApp.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public ICollection<FeedbackViewModel> Feedbacks { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
        public DateTime Date { get; set; }
    }
}