using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Entities;
using Theater.DAL.Views;

namespace Theater.DAL
{
    public class TheaterContext : DbContext
    {
        public TheaterContext():base("Theater")
        {
            Database.SetInitializer<TheaterContext>(null);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Play> Plays { get; set; }
     //   public DbSet<PlayActor> PlayActors { get; set; }

        public DbSet<PlayView> PlayViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Play>()
                .HasMany(a => a.Actors)
                .WithMany(p => p.Plays)
                .Map(m =>
                {
                    m.MapLeftKey("PlayId");
                    m.MapRightKey("ActorId");
                    m.ToTable("PlayActor");
                });
        }

    }
}
