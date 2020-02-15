using System.Collections.Generic;

namespace BlogMvcApp.DLL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
