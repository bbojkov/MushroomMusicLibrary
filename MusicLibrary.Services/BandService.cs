using System.Collections.Generic;
using MusicLibrary.Models;
using MusicLibrary.Data;
using System.Data.Entity;
using System.Linq;

namespace MusicLibrary.Services
{
    public class BandService : IBandService
    {
        private readonly IMusicLibraryContext libraryContext;

        public BandService(IMusicLibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }
        
        public IEnumerable<Band> GetAllBands()
        {
            return this.libraryContext.Bands.Include(c => c.Country).Include(g => g.Genre);
        }

        public IEnumerable<Band> GetBands(string letter)
        {
            return this.libraryContext.Bands.Where(x => x.BandName.Substring(0, 1) == letter).ToList();

        }
    }
}
