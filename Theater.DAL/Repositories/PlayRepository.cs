using System;
using System.Collections.Generic;
using System.Text;
using Theater.DAL.Entities;
using System.Data.Entity;
using System.Linq;

namespace Theater.DAL.Repositories
{
    public class PlayRepository : IRepository<Play>
    {
        private TheaterContext context;

        public PlayRepository(TheaterContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            Play play = context.Plays.Find(id);
            if (play != null)
            {
                context.Plays.Remove(play);
            }
        }

        public void Delete(Play entity)
        {
            context.Plays.Remove(entity);
        }

        public IList<Play> GetAll()
        {
            return context.Plays.ToList();
        }

        public Play GetById(int id)
        {
            return context.Plays.Find(id);
        }

        public void Insert(Play entity)
        {
            context.Plays.Add(entity);
        }

        public void Update(Play entity)
        {
            var play = context.Plays.Find(entity.Id);
            context.Entry(entity).CurrentValues.SetValues(play);
        }

        
    }
}
