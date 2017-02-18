using Microsoft.AspNet.Identity.EntityFramework;
using MusicLibrary.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicLibrary.Data
{
    public class MusicLibraryContext : IdentityDbContext<User>, IMusicLibraryContext
    {
        public MusicLibraryContext()
            : base("MusicLibrary")
        {
        }

        public override IDbSet<User> Users
        {
            get { return base.Users; }
            set { base.Users = value; }
        }

        public IDbSet<Band> Bands { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public static MusicLibraryContext Create()
        {
            return new MusicLibraryContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
