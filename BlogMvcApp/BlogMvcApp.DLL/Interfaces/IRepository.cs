using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogMvcApp.DLL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);

        void Create(T item);

        void Update(T item);
        void LoadExplicitCollection(string collectionName, T item);
        void Delete(int id);

        DbSet<T> GetDbSet();
    }
}