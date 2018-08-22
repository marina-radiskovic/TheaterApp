using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.DAL.Views
{
    [Table("PlayView", Schema = "dbo")]
    public class PlayView
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Photo")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }

        [DisplayName("Scheduled time")]
        public DateTime? ScheduledTime { get; set; }
        public string Actors { get; set; }

        //public virtual IList<PlayActor> PlayActors { get; set; }
    }
}
