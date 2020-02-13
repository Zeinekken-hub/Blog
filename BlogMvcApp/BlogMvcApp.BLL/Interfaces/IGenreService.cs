using BlogMvcApp.DLL.Entities;
using System.Collections.Generic;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();

        Genre GetGenreByName(string name);
    }
}
