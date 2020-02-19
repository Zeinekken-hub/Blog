using BlogMvcApp.DLL.Entities;
using Microsoft.AspNet.Identity;

namespace BlogMvcApp.DLL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        { }
    }
}
