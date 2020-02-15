using BlogMvcApp.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogMvcApp.DLL.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext(string connectionString) : base(connectionString)
        {
        }

        public BlogContext() : base("DefaultConnection")
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Tag> Tags { get; set; }

        static BlogContext()
        {
            Database.SetInitializer(new BlogInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(a => a.Tags).WithMany(a => a.Articles);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class BlogInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var articles = new List<Article>()
            {
                new Article
                {
                    Author = "A che?))",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Title = "Not bad for the first time",
                    Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                    "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                    "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
                    "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                },
                new Article
                {
                    Author = "A)",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Title = "Not bad for the first time",
                    Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                    "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                    "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
                    "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                new Article
                {
                    Author = "??????????",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Title = "Not bad for the first time",
                    Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                    "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                    "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                    "remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, " +
                    "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                }
            };


            var q = new Questionnaire
            {
                IsAlone = true,
                IsStable = false,
                Gender = "Male",
                Id = 1,
                FirstName = "Boh",
                LastName = "Mu"
            };

            context.Tags.AddRange(new List<Tag>
            {
                new Tag {Id = 1, Name = "Social"},
                new Tag {Id = 2, Name = "Life"},
                new Tag {Id = 3, Name = "Education"},
                new Tag {Id = 4, Name = "Motivation"}
            });

            context.Questionnaires.Add(q);
            context.Articles.AddRange(articles);
            base.Seed(context);
        }
    }
}