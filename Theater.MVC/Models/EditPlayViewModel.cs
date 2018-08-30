using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Theater.DAL.Entities;

namespace Theater.MVC.Models
{
    public class EditPlayViewModel
    {
        public EditPlayViewModel()
        {
            AllActors = new List<Actor>();
            SelectedActorsIds = new List<int>();
        }

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
        public DateTime? ScheduledTime { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string ActorsString { get; set; }

        public IList<int> CurrentActorsIds { get; set; }
        public IList<Actor> AllActors { get; set; }
        public List<int> SelectedActorsIds { get; set; }
    }
}
