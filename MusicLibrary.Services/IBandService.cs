using MusicLibrary.Models;
using System.Collections.Generic;

namespace MusicLibrary.Services
{
    public interface IBandService
    {
        IEnumerable<Band> GetAllBands();

        IEnumerable<Band> GetBands(string letter);

        IEnumerable<Band> GetBandsByGenre(string genre);
    }
}
