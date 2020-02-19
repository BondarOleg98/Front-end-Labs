using KaratePortal.Models.KarateTeam;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class KaratePersonContext : DbContext
    {
        public DbSet<KarateStudent> KarateStudents { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }

        public KaratePersonContext() : base("DefaultConnection")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().HasMany(c => c.KarateStudents)
                .WithMany(ks => ks.Coaches)
                .Map(t => t.MapLeftKey("CoachId")
                .MapRightKey("KarateStudentId")
                .ToTable("CoachKarateStudent"));
        }
    }
}