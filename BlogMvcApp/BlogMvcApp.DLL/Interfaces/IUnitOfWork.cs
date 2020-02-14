using BlogMvcApp.DLL.Entities;
using System;

namespace BlogMvcApp.DLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Feedback> Feedbacks { get; }
        IRepository<Article> Articles { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Questionnaire> Questionnaires { get; }
        void Save();
    }
}