using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class User : IdentityUser
    {
        // HERE COMES THE CUSTOM FIELDS FOR THE USERS
        private ICollection<Band> likedBands;

        public User()
        {
            this.likedBands = new HashSet<Band>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        [ForeignKey("BandId")]
        public virtual ICollection<Band> LikedBands
        {
            get { return this.likedBands; }
            set { this.likedBands = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
