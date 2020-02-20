using BlogMvcApp.DLL.Entities;
using Microsoft.AspNet.Identity;

namespace BlogMvcApp.DLL.Identity
{
    public class BlogUserManager : UserManager<BlogUser>
    {
        public BlogUserManager(IUserStore<BlogUser> store)
            : base(store)
        {
        }
    }
}
