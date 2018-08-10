using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.DAL.Entities

{
    public class PlayActor
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int PlayId { get; set; }

        public virtual Play Play { get; set; }
    }
}