using MusicLibrary.Models;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Services
{
    public interface IBandService
    {
        Band GetById(Guid id);

        IEnumerable<Band> GetAllBands();

        IEnumerable<Band> GetBands(string letter);

        IEnumerable<Band> GetBandsByGenre(string genre);

        bool RegisterNewBand(string bandName, int formationYear, Guid genreId, Guid countryId);
    }
}
