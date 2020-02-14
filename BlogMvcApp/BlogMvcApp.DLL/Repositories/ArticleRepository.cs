using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogMvcApp.DLL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Article item)
        {
            _context.Articles.Add(item);
        }

        public void Delete(int id)
        {
            var itemToDelete = _context.Articles.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
                itemToDelete.IsDeleted = true;
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return _context.Articles.Include(a => a.Feedbacks)
                .AsEnumerable()
                .Where(predicate)
                .ToList();
        }

        public Article Get(int id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }

        public void Update(Article item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public DbSet<Article> GetDbSet()
        {
            return _context.Articles;
        }
    }
}