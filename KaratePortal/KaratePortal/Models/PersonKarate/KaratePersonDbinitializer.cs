using KaratePortal.Models.KarateTeam;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class KaratePersonDbinitializer : DropCreateDatabaseAlways<KaratePersonContext>
    {
        protected override void Seed(KaratePersonContext context)
        {
            KarateStudent ks1 = new KarateStudent
            {
                Id = 1,
                Name = "Oleg",
                LastName = "Bondar",
                Age = 20,
                Belt = "black-II",
                Country = "Ukraine",
                City = "Vyshgorod",
                YearsTraining = 2007,
                CountCoach = 4,
                SportsmanStatus = "active",
                LikeCompetition = "Universal",
                TeamId = 1
            };
            KarateStudent ks2 = new KarateStudent
            {
                Id = 2,
                Name = "Vanya",
                LastName = "Sytnikov",
                Age = 15,
                Belt = "brown",
                Country = "Ukraine",
                City = "Kyiv",
                YearsTraining = 2012,
                CountCoach = 1,
                SportsmanStatus = "active",
                LikeCompetition = "fight",
                TeamId = 1
            };

            context.KarateStudents.Add(ks1);
            context.KarateStudents.Add(ks2);

           
            Coach c2 = new Coach
            {
                Id = 2,
                Name = "Oleksandr",
                LastName = "Chertkov",
                Age = 35,
                Belt = "black-II",
                Country = "Ukraine",
                City = "Vyshgorod",
                
            };

           
            context.Coaches.Add(c2);
            Team t1 = new Team
            {
                Id = 1,
                Name = "MamukaDojo",
                Coach = "Mamuka",
                Organization = "Kyokushinkan",
                KarateStudents = new List<KarateStudent>() { ks1}
            };
            Team t2 = new Team
            {
                Id = 2,
                Name = "TempoDojo",
                Coach = "Vasiliev",
                Organization = "Kyokushinkan",
                KarateStudents = new List<KarateStudent>() { ks2 }
            };
            context.Teams.Add(t1);
            context.Teams.Add(t2);
          
            base.Seed(context);
        }
       
    }
}