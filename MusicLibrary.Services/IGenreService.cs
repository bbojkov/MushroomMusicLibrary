using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}
