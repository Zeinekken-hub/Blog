using BlogMvcApp.DLL.Entities;
using System;
using BlogMvcApp.DLL.Identity;

namespace BlogMvcApp.DLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Feedback> Feedbacks { get; }
        IRepository<Article> Articles { get; }
        IRepository<Questionnaire> Questionnaires { get; }
        IRepository<Tag> Tags { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        ApplicationUserManager UserManager { get; }
        void Save();
    }
}