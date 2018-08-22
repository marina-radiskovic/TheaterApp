using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.DAL.Entities

{
    [Table("Play", Schema = "dbo")]
    public class Play
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImageType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime? ScheduledTime { get; set; }

        public virtual IList<Actor> Actors { get; set; }
    }
}