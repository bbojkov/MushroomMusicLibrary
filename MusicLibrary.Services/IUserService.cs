using MusicLibrary.Models;
using System;

namespace MusicLibrary.Services
{
    public interface IUserService
    {
        User GetUserById(string id);

        void AddBandToFavorites(string userId, Band band);

        //void RemoveBandFromFavorites(Guid bandId, User user);
    }
}
