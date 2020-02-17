using BlogMvcApp.DLL.EF;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogMvcApp.DLL.Repositories
{
    public class QuestionnaireRepository : IRepository<Questionnaire>
    {
        private readonly BlogContext _context;
        public QuestionnaireRepository(BlogContext context)
        {
            _context = context;
        }

        public void Create(Questionnaire item)
        {
            _context.Questionnaires.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questionnaire> Find(Func<Questionnaire, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Questionnaire Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Questionnaire> GetAll()
        {
            throw new NotImplementedException();
        }

        public DbSet<Questionnaire> GetDbSet()
        {
            throw new NotImplementedException();
        }

        public void LoadExplicitCollection(string collectionName, Questionnaire item)
        {
            throw new NotImplementedException();
        }

        public void Update(Questionnaire item)
        {
            throw new NotImplementedException();
        }
    }
}
