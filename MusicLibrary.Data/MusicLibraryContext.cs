using System.Data.Entity;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MusicLibraryContext : DbContext, IMusicLibraryContext
    {

        public MusicLibraryContext()
            : base("MusicLibrary")
        {

        }

        public IDbSet<Band> Bands { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Genre> Genres { get; set; }
    }
}
