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
        private GenreRepository _genreRepository;
        private QuestionnaireRepository _questionnaireRepository;

        public EFUnitOfWork(string connection)
        {
            _context = new BlogContext(connection);
        }

        public IRepository<Genre> Genres => _genreRepository
                                            ?? (_genreRepository = new GenreRepository(_context));

        public IRepository<Feedback> Feedbacks => _feedbackRepository
                                                  ?? (_feedbackRepository = new FeedbackRepository(_context));

        public IRepository<Article> Articles => _articleRepository
                                                ?? (_articleRepository = new ArticleRepository(_context));

        public IRepository<Questionnaire> Questionnaires => _questionnaireRepository
                                                            ?? (_questionnaireRepository =
                                                                new QuestionnaireRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}