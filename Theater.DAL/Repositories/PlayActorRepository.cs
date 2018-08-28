using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Entities;

namespace Theater.DAL.Repositories
{
    public class PlayActorRepository
    {
        TheaterContext context;

        public PlayActorRepository(TheaterContext context)
        {
            this.context = context;
        }

        public void Insert(PlayActor playActorRecord)
        {
            context.PlayActors.Add(playActorRecord);
        }
    }
}
