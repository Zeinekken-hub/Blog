using BlogMvcApp.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IArticleService : IDisposable
    {
        IEnumerable<Article> GetArticles();

        IEnumerable<Article> GetArticlesByTagName(string tagName);
        DbSet<Tag> GetArticleTags();

        Article GetArticleById(int id);

        void EditArticle(Article article, ICollection<string> tagNames);

        IEnumerable<Article> GetArticlesByGenreMood(Questionnaire questionnaire);

        void CreateArticle(Article article);

        void DeleteArticle(Article article);

        void DeleteArticle(int id);
        Tag GetTagByName(string tagName);
    }
}
