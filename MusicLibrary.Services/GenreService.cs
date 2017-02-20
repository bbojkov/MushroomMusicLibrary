using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using MusicLibrary.Data;
using MusicLibrary.Models.Factories;

namespace MusicLibrary.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMusicLibraryContext musicLibraryContext;
        private readonly IMusicLibraryBaseContext baseContext;
        private readonly IGenreFactory genreFactory;

        public GenreService(IMusicLibraryContext musicLibraryContext, IMusicLibraryBaseContext baseContext, IGenreFactory genreFactory)
        {
            if (genreFactory == null)
                throw new ArgumentNullException(nameof(genreFactory));
            if (baseContext == null)
                throw new ArgumentNullException(nameof(baseContext));

            this.musicLibraryContext = musicLibraryContext;
            this.baseContext = baseContext;
            this.genreFactory = genreFactory;
        }

        public Genre CreateGenre(string genreName)
        {
            var genre = genreFactory.CreateGenreInstance();
            genre.Id = Guid.NewGuid();
            genre.GenreName = genreName;

            this.musicLibraryContext.Genres.Add(genre);
            this.baseContext.SaveChanges();

            return this.musicLibraryContext.Genres.Where(x => x.GenreName == genreName).FirstOrDefault();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return this.musicLibraryContext.Genres.OrderBy(x => x.GenreName).ToList();
        }

        public Genre GetGenre(Guid genreId)
        {
            return this.musicLibraryContext.Genres.Find(genreId);
        }
    }
}
