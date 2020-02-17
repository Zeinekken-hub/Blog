using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;

namespace BlogMvcApp.DLL.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly BlogContext _context;
        public TagRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Tag item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Tag Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags;
        }

        public DbSet<Tag> GetDbSet()
        {
            return _context.Tags;
        }

        public void LoadExplicitCollection(string collectionName, Tag item)
        {
            throw new NotImplementedException();
        }

        public void Update(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
