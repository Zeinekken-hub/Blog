using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlogMvcApp.BLL.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork Database { get; }
        public GenreService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public Genre GetGenreByName(string name)
        {
            return Database.Genres
                .GetAll()
                .FirstOrDefault(genre => genre.Name == name);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return Database.Genres.GetAll();
        }
    }
}
