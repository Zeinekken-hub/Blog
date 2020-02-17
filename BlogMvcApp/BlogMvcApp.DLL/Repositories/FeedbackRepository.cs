using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogMvcApp.DLL.Repositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private readonly BlogContext _context;

        public FeedbackRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Feedback item)
        {
            _context.Feedbacks.Add(item);
        }

        public void Delete(int id)
        {
            var itemToDelete = _context.Feedbacks.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
                _context.Feedbacks.Remove(itemToDelete);
        }

        public IEnumerable<Feedback> Find(Func<Feedback, bool> predicate)
        {
            return _context.Feedbacks.Where(predicate).ToList();
        }

        public Feedback Get(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks;
        }

        public DbSet<Feedback> GetDbSet()
        {
            return _context.Feedbacks;
        }

        public void Update(Feedback item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void LoadExplicitCollection(string collectionName, Feedback item)
        {
            _context.Entry(item).Collection(collectionName).Load();
        }
    }
}