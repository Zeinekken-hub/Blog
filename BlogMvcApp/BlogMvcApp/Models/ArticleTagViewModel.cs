using PagedList;

namespace BlogMvcApp.Models
{
    public class ArticleTagViewModel
    {
        public IPagedList<ArticleAdViewModel> Articles { get; set; }
        public TagViewModel Tag { get; set; }
        public int PageSize { get; set; }
    }
}