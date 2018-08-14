using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Theater.MVC.Models
{
    public class PlayViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }
        public string Description { get; set; }

        [DisplayName("Scheduled time")]
        [DataType(DataType.DateTime)]
        public DateTime? ScheduledTime { get; set; }

        //public virtual IList<PlayActor> PlayActors { get; set; }
    }
}