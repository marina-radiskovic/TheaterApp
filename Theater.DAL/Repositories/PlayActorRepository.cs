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
        private TheaterContext context;

        public PlayActorRepository(TheaterContext context)
        {
            this.context = context;
        }

        public void Insert(PlayActor playActorRecord)
        {
            context.PlayActors.Add(playActorRecord);
        }

        public IList<PlayActor> GetPlayActorsForPlayId(int id)
        {
            return context.PlayActors.Where(x => x.PlayId == id).ToList();
        }

        public void Delete(int id)
        {
            PlayActor playActor = context.PlayActors.Find(id);
            if (playActor != null)
            {
                context.PlayActors.Remove(playActor);
            }
        }
    }
}
