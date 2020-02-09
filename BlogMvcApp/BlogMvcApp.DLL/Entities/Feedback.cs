using System;

namespace BlogMvcApp.DLL.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }

        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }
    }
}