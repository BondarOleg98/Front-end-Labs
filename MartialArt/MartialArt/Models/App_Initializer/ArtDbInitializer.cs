using MartialArt.Models.App_Context;
using System.Data.Entity;

namespace MartialArt.Models.App_Initializer
{
    public class ArtDbInitializer : CreateDatabaseIfNotExists<ArtContext>
    {
        protected override void Seed(ArtContext db)
        {
            db.Arts.Add(new Art { Name = "Karate", CountCountry = 1, Year = 1863 });
            db.Arts.Add(new Art { Name = "KungFu", CountCountry = 12, Year = 1862 });
            db.Arts.Add(new Art { Name = "Sambo", CountCountry = 13, Year = 1896 });

            base.Seed(db);
        }

    }
}