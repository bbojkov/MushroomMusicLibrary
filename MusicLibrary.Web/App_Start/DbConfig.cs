using MusicLibrary.Data;
using MusicLibrary.Data.Migrations;
using System.Data.Entity;

namespace MusicLibrary.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryContext, Configuration>());
            MusicLibraryContext.Create().Database.CreateIfNotExists();
        }
    }
}