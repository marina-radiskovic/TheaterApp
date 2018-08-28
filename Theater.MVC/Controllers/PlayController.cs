using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Theater.DAL;
using Theater.DAL.DTO;
using Theater.DAL.Entities;
using Theater.DAL.Views;
using Theater.MVC.Models;
using Theater.Service;
using Theater.Service.ActorService;
using Theater.Service.PlayActorService;
using Theater.Service.PlayService;

namespace Theater.MVC.Controllers
{
    public class PlayController : Controller
    {
        private readonly PlayService _playService = new PlayService();
        private readonly ActorService _actorService = new ActorService();
        private readonly PlayActorService _playActorService = new PlayActorService();

        // GET: Play/Index
        public ActionResult Index(int? page)
        {
            //var playViewList = new PlaysListViewModel();
            //playViewList.PlayList = _playService.GetAllPlays();
            //foreach (var playView in playViewList.PlayList)
            //{
            //    playView.ImageVirtualPath = string.Format("{0}{1}", WebConfigurationManager.AppSettings["appUrl"].ToString(), playView.ImageVirtualPath.ToString());
            //}
            //PagedList<PlayView> model = new PagedList<PlayView>(playViewList.PlayList, pageNumber, pageSize);
            
                var modelList = _playService.GetPlayViewsToPagedList(page);
                return View(modelList);

        }

        // GET: Play/AddNewPlay
        public ActionResult AddNewPlay()
        {
            var playViewModel = new PlayViewModel();
            playViewModel.Actors = _actorService.GetAllActors();
            return View(playViewModel);
        }

        [HttpPost]
        public ActionResult AddNewPlay(PlayViewModel model)
        {
            if (model.SelectedActorsIds.Count == 0)
            {
                ModelState.AddModelError(nameof(PlayViewModel.SelectedActorsIds), "Please select actors for this play.");
                model.Actors = _actorService.GetAllActors();
                return View(model);
            }

            if (ModelState.IsValid)
            {
                if (model.File.ContentLength > 0 && model.File.ContentType.Contains("image"))
                {
                    var imageFolderPath = Server.MapPath(WebConfigurationManager.AppSettings["imagePath"].ToString());
                    var fileName = Guid.NewGuid().ToString();
                    string virtualPath = string.Format("{0}{1}{2}", WebConfigurationManager.AppSettings["virtualImagePath"].ToString(), fileName, Path.GetExtension(model.File.FileName).ToLower());
                    string path = string.Format("{0}{1}{2}", imageFolderPath, Path.GetFileName(fileName), Path.GetExtension(model.File.FileName).ToLower());
                    model.File.SaveAs(path);

                    PlayWithActors playWithActors = new PlayWithActors
                    {
                        Title = model.Title,
                        ImagePath = path,
                        ImageVirtualPath = virtualPath,
                        ImageType = Path.GetExtension(model.File.FileName),
                        Description = model.Description,
                        ScheduledTime = model.ScheduledTime,
                        ActorsIds = model.SelectedActorsIds
                    };

                    _playService.CreatePlay(playWithActors);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(PlayViewModel.File), "File must be image type!");
                    model.Actors = _actorService.GetAllActors();
                    return View(model);
                }
            }
            else
            {
                model.Actors = _actorService.GetAllActors();
                return View(model);
            }
        }


    }
}