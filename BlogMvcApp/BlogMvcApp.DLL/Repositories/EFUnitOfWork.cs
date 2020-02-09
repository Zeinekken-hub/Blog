using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System;

namespace BlogMvcApp.DLL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        private ArticleRepository _articleRepository;
        private FeedbackRepository _feedbackRepository;

        public EFUnitOfWork(string connection)
        {
            _context = new BlogContext(connection);
        }

        public IRepository<Feedback> Feedbacks
        {
            get
            {
                if (_feedbackRepository == null)
                    _feedbackRepository = new FeedbackRepository(_context);
                return _feedbackRepository;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository(_context);
                return _articleRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}