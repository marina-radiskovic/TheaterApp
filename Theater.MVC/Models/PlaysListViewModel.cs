using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Theater.DAL.Views;

namespace Theater.MVC.Models
{
    public class PlaysListViewModel
    {
        public IList<PlayView> PlayList { get; set; }
    }
}