using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;

namespace BlogMvcApp.DLL.Repositories
{
    public class ClientManager : IClientManager
    {
        private readonly BlogContext _context;
        public ClientManager(BlogContext context)
        {
            _context = context;
        }
        public void Create(ClientProfile item)
        {
            _context.ClientProfiles.Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
