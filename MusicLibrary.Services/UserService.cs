using System;
using System.Linq;
using MusicLibrary.Models;
using MusicLibrary.Data;

namespace MusicLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IMusicLibraryContext musicLibraryContext;

        public UserService(IMusicLibraryContext musicLibraryContext)
        {
            this.musicLibraryContext = musicLibraryContext;
        }

        public User GetUserById(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return this.musicLibraryContext.Users.Find(id);
            }
        }

        public void AddBandToFavorites(string userId, Band band)
        {
            var user = this.GetUserById(userId);
            user.LikedBands.Add(band);

            musicLibraryContext.SaveChanges();
        }

        //public void RemoveBandFromFavorites(Guid bandId, User user)
        //{
        //    var band = user.LikedBands.SingleOrDefault(x => x.Id == bandId);
        //    user.LikedBands.Remove(band);

        //    musicLibraryContext.SaveChanges();
        //}
    }
}
