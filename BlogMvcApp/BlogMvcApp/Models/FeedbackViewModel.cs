using System;

namespace BlogMvcApp.Models
{
    public class FeedbackViewModel
    {
        public string Text { get; set; }
        public int Mark { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}