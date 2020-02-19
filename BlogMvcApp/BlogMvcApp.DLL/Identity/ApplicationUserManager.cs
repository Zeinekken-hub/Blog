using BlogMvcApp.DLL.Entities;
using Microsoft.AspNet.Identity;

namespace BlogMvcApp.DLL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}
