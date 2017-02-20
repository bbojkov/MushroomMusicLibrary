using MusicLibrary.Models;
using System.Collections.Generic;
using System;

namespace MusicLibrary.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        Country GetCountry(Guid countryId);
    }
}
