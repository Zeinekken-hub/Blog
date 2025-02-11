﻿using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogMvcApp.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private IUnitOfWork Database { get; }

        public ArticleService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Article GetArticleById(int id)
        {
            var article = Database.Articles.GetDbSet()
                .Include(a => a.Tags)
                .Include(p => p.Feedbacks)
                .FirstOrDefault(a => a.Id == id);

            return article;
        }

        public IEnumerable<Article> GetArticles()
        {
            return Database.Articles.GetAll().Where(article => !article.IsDeleted);
        }

        public IEnumerable<Article> GetArticlesByTagName(string tagName)
        {
            if (tagName == "All")
                return Database.Articles.GetAll().Where(article => !article.IsDeleted).ToList();

            return Database.Articles.GetDbSet()
                .Include(article => article.Tags)
                .Where(article => article.Tags.Any(tag => tag.Name == tagName
                && !article.IsDeleted))
                .ToList();
        }

        public void EditArticle(Article article, ICollection<string> tagNames)
        {
            var newArticle = GetArticleById(article.Id);
            newArticle.Date = article.Date;
            newArticle.BlogUser = article.BlogUser;
            newArticle.Text = article.Text;
            newArticle.IsDeleted = article.IsDeleted;
            newArticle.Title = article.Title;
            newArticle.Tags.Clear();

            foreach (var tag in tagNames)
            {
                newArticle.Tags.Add(GetTagByName(tag));
            }

            Database.Articles.Update(newArticle);
            Database.Save();
        }

        public IEnumerable<Article> GetArticlesByGenreMood(Questionnaire q)
        {
            return Database.Articles.GetDbSet();
        }

        public void CreateArticle(Article article)
        {
            Database.Articles.Create(article);
            Database.Save();
        }

        public void DeleteArticle(int id)
        {
            Database.Articles.Delete(id);
            Database.Save();
        }

        public void DeleteArticle(Article article)
        {
            Database.Articles.Delete(article.Id);
            Database.Save();
        }

        public DbSet<Tag> GetArticleTags()
        {
            return Database.Tags.GetDbSet();
        }

        public Tag GetTagByName(string tagName)
        {
            return Database.Tags.GetAll().FirstOrDefault(tag => tag.Name == tagName);
        }

        public void EditArticleWithTags(Article article, ICollection<Tag> tags)
        {
            Database.Articles.Update(article);
            Database.Articles.LoadExplicitCollection("Tags", article);
            article.Tags.Clear();
            article.Tags = tags;
            Database.Save();
        }
    }
}
