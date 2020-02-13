using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogMvcApp.DLL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {

        private readonly BlogContext _context;

        public GenreRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Genre item)
        {
            _context.Genres.Add(item);
        }

        public void Delete(int id)
        {
            return;
        }

        public IEnumerable<Genre> Find(Func<Genre, bool> predicate)
        {
            return _context.Genres.Where(predicate).ToList();
        }

        public Genre Get(int id)
        {
            return _context.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres;
        }

        public DbSet<Genre> GetDbSet()
        {
            return _context.Genres;
        }

        public void Update(Genre item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
