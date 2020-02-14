using BlogMvcApp.DLL.Entities;
using System;
using System.Collections.Generic;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IArticleService : IDisposable
    {
        IEnumerable<Article> GetArticles();

        IEnumerable<Article> GetArticlesByGenre(Genre genre);

        Article GetArticleById(int id);

        void EditArticle(Article article);

        IEnumerable<Article> GetArticlesByGenreMood(Questionnaire questionnaire);

        void CreateArticle(Article article);

        void DeleteArticle(Article article);

        void DeleteArticle(int id);
    }
}
