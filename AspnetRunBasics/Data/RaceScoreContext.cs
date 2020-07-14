using RaceScore.Entities;
using Microsoft.EntityFrameworkCore;

namespace RaceScore.Data
{
    public class RaceScoreContext : DbContext
    {
        public RaceScoreContext(DbContextOptions<RaceScoreContext> options)
            : base(options)
        {
        }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().HasData(
                new Race
                {
                    Id = 1,
                    Name = "Jarunska Desetka",
                    Active = true
                },
                new Race
                {
                    Id = 2,
                    Name = "Sljemenski maraton",
                    Active = true
                },
                new Race
                {
                    Id = 3,
                    Name = "Proljetni cener",
                    Active = true
                },
                new Race
                {
                    Id = 4,
                    Name = "Zagrebački maraton",
                    Active = true
                },
                new Race
                {
                    Id = 5,
                    Name = "Wings for life",
                    Active = true
                },
                new Race
                {
                    Id = 6,
                    Name = "Grawe noćni maraton",
                    Active = true
                }
                );
        }
    }
}
