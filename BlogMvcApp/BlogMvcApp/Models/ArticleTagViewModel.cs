using System.Collections.Generic;

namespace BlogMvcApp.Models
{
    public class ArticleTagViewModel
    {
        public IEnumerable<ArticleAdViewModel> Articles { get; set; }
        public TagViewModel Tag { get; set; }
    }
}