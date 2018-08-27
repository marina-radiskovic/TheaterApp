using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.DAL.Entities

{
    [Table("Actor", Schema = "dbo")]
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<Play> Plays { get; set; }

       // [Display(Name = "Actors")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
