using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.Views;

namespace Theater.DAL.Repositories
{
    public class PlayViewRepository
    {
        private TheaterContext context;

        public PlayViewRepository(TheaterContext context)
        {
            this.context = context;
        }

        public PlayView GetPlayView(int id)
        {
            return context.PlayViews.Find(id);
        }
    }
}
