using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater.DAL.Entities

{
    [Table("PlayActor", Schema="dbo")]
    public class PlayActor
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
        public virtual Actor Actor { get; set; }
    }
}