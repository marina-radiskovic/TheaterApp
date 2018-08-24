using System;
using System.Collections.Generic;
using System.Text;
using Theater.MVC.Models;

namespace Theater.DAL.Entities

{
    public class ActorListModel
    {
        public IList<Actor> ActorList { get; set; }
    }
}