using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Entities;

namespace Theater.DAL.Repositories
{
    public class ActorRepository
    {
        private TheaterContext context;

        public ActorRepository(TheaterContext context)
        {
            this.context = context;
        }

        public IList<Actor> GetAll()
        {
            return context.Actors.ToList();
        }
    }
}
