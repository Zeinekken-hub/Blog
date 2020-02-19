using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogMvcApp.DLL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
