using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogMvcApp.DLL.Entities
{
    public class BlogUser : IdentityUser
    {
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
