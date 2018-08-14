using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Theater.DAL.Entities;
using Theater.MVC.Models;
using Theater.Service.PlayService;

namespace Theater.MVC.Controllers
{
    public class PlayController : Controller
    {
        private readonly PlayService _playService = new PlayService();

        // GET: Play/Index
        public ActionResult Index()
        {
            return View(_playService.GetAllPlays());
        }

        // GET: Play/AddNewPlay
        public ActionResult AddNewPlay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewPlay(PlayViewModel model)
        {
            if (ModelState.IsValid)
            {
                Play play = new Play
                {
                    Title = model.Title,
                    ImagePath = model.ImagePath,
                    Description = model.Description,
                    ScheduledTime = model.ScheduledTime
                };
                _playService.InsertPlay(play);
            }
            return RedirectToAction("Index");
        }


    }
}