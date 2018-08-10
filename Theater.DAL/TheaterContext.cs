using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Entities;

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
        public DbSet<PlayActor> PlayActors { get; set; }
    }
}
