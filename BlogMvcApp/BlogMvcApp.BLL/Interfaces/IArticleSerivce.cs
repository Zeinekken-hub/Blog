using BlogMvcApp.DLL.Entities;
using System;
using System.Collections.Generic;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IArticleSerivce : IDisposable
    {
        IEnumerable<Article> GetArticles();

        IEnumerable<Article> GetArticlesByGenre(Genre genre);

        Article GetArticleById(int id);

        void EditArticle(Article article);

        IEnumerable<Article> GetArticlesByGenreMood(bool mood);

        void Create(Article article);

        void Delete(Article article);

        void Delete(int id);
    }
}
