using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theater.DAL.Entities;
using Theater.MVC.Models.Validation;

namespace Theater.MVC.Models
{
    [Validator(typeof(PlayViewModelValidator))]
    public class PlayViewModel
    {
        public PlayViewModel()
        {
            Actors = new List<Actor>();
            SelectedActorsIds = new List<int>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        
        [DisplayName("Image")]
        public string ImagePath { get; set; }
        
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }

        [DisplayName("Start date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Scheduled time")]
        public TimeSpan? Time { get; set; }
        public TimeSpan? Duration { get; set; }
        
        public HttpPostedFileBase File { get; set; }
        public string ActorsString { get; set; }
        public bool? Canceled { get; set; }

        public IList<Actor> Actors { get; set; }
        public List<int> SelectedActorsIds { get; set; }

        [DisplayName("Showing period")]
        public string showingPeriod
        {
            get
            {
                return StartDate.Value.ToString("dd.MMM.yyyy.") + " - " + EndDate.Value.ToString("dd.MMM.yyyy.") + " at " + Time.Value.ToString(@"hh\:mm") + "h";
            }
        }
    } 
}