using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Repositories;
using Theater.DAL.Entities;

namespace Theater.DAL
{
    public class UnitOfWork : IDisposable
    {
        public TheaterContext context;
        public PlayRepository PlayRepository { get; private set; }
        public ActorRepository ActorRepository { get; private set; }
        
        public PlayViewRepository PlayViewRepository { get; private set; }
        private static UnitOfWork instance = null;

        private UnitOfWork()
        {
            this.context = new TheaterContext();
            PlayRepository = new PlayRepository(context);
            ActorRepository = new ActorRepository(context);
            
            PlayViewRepository = new PlayViewRepository(context);
        }

        public static UnitOfWork GetUnitOfWork()
        {
            if (instance == null)
            {
                instance = new UnitOfWork();
            }
            return instance;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            PlayRepository = null;
            instance = null;
        }
    }
}
