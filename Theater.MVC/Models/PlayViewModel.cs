using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theater.DAL.Entities;

namespace Theater.MVC.Models
{
    public class PlayViewModel
    {
        public PlayViewModel()
        {
            Actors = new List<Actor>();
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

        [DisplayName("Start date")]
        [Required(ErrorMessage = "Scheduled time is required!")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Scheduled time")]
        public TimeSpan? Time { get; set; }
        public TimeSpan? Duration { get; set; }

        [Required(ErrorMessage = "Please upload photo")]
        public HttpPostedFileBase File { get; set; }
        public string ActorsString { get; set; }
        public bool? Canceled { get; set; }

        public IList<Actor> Actors { get; set; }
        public List<int> SelectedActorsIds { get; set; }
    } 
}