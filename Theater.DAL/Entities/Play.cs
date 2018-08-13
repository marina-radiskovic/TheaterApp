using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.DAL.Entities

{
    [Table("Play", Schema = "dbo")]
    public class Play
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //TODO: ImagePath would be better if this is a path to file
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduledTime { get; set; }

        public virtual IList<PlayActor> PlayActors { get; set; }
    }
}