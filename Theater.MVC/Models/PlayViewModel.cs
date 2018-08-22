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

        [Required(ErrorMessage = "The title is required!")]
        public string Title { get; set; }
        
        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Type a short description.")]
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }

        [DisplayName("Scheduled time")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        [Required(ErrorMessage = "Scheduled time is required!")]
        public DateTime? ScheduledTime { get; set; }

        [Required(ErrorMessage = "Please upload photo")]
        public HttpPostedFileBase File { get; set; }

        //public virtual IList<PlayActor> PlayActors { get; set; }
    }
}