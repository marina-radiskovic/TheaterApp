using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.DAL.Views
{
    [Table("PlayView", Schema = "dbo")]
    public class PlayView
    {
        [Key]
        public int PlayId { get; set; }
        public string Title { get; set; }

        [DisplayName("Photo")]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? Time { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Actors { get; set; }
        public bool? Canceled { get; set; }

        [DisplayName("Showing period")]
        public string showingPeriod
        {
            get
            {
                return StartDate.Value.ToString("dd.MMM.yyyy.") + " - " + EndDate.Value.ToString("dd.MMM.yyyy.") + " at " + Time.Value.ToString(@"hh\:mm") + "h";
            }
        }

        [DisplayName("Duration")]
        public string durationString
        {
            get
            {
                return Duration.Value.ToString(@"hh\:mm") + "h";
            }
        }

    }
}
