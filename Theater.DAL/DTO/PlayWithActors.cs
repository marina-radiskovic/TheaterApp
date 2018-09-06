using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Theater.DAL.Entities;

namespace Theater.DAL.DTO
{
    public class PlayWithActors
    {
        public PlayWithActors()
        {
            ActorsIds = new List<int>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? Time { get; set; }
        public TimeSpan? Duration { get; set; }
        public HttpPostedFileBase File { get; set; }
        public bool? Canceled { get; set; }

        public IList<int> ActorsIds { get; set; }
    }
}
