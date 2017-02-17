using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MusicLibrary.Models;

namespace MusicLibrary.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MusicLibraryContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicLibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            return;

            IList<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = Guid.NewGuid(), GenreName = "Metal"}
            };

            IList<Country> countries = new List<Country>()
            {
                new Country() {Id = Guid.NewGuid(), CountryName = "Bulgaria" },
                new Country() {Id = Guid.NewGuid(), CountryName = "Finland" }
            };

            IList<Band> bands = new List<Band>()
            {
                new Band() {Id = Guid.NewGuid(), BandName = "A day to remember", Country = countries[0], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Aerosmith", Country = countries[0], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Behemoth", Country = countries[1], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Demon Hunter", Country = countries[0], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Faith No More", Country = countries[1], Genre = genres[0] },
            };

            context.Bands.AddOrUpdate(bands.ToArray());
        }
    }
}
