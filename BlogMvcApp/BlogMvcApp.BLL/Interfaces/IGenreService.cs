using BlogMvcApp.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();

        Genre GetGenreByName(string name);
    }
}
