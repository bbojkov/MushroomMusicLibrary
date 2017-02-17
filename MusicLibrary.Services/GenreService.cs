using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using MusicLibrary.Data;

namespace MusicLibrary.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMusicLibraryContext musicLibraryContext;

        public GenreService(IMusicLibraryContext musicLibraryContext)
        {
            this.musicLibraryContext = musicLibraryContext;
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            return this.musicLibraryContext.Genres.OrderBy(x => x.GenreName).ToList();
        }
    }
}
