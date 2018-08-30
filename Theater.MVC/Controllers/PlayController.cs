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
        private readonly PlayViewService _playViewService = new PlayViewService();

        // GET: Play/Index
        public ActionResult Index(int? page)
        {
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

        public ActionResult Edit(int id)
        {
            var playView = _playViewService.GetPlayView(id);

            var model = new EditPlayViewModel
            {
                Id = playView.Id,
                Title = playView.Title,
                Description = playView.Description,
                ScheduledTime = playView.ScheduledTime,
                ActorsString = playView.Actors,
                ImageVirtualPath = playView.ImageVirtualPath,
                ImagePath = playView.ImagePath,
                ImageType = playView.ImageType,
                AllActors = _actorService.GetAllActors()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPlayViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentStatePlayView = _playViewService.GetPlayView(model.Id);
                if (model.ScheduledTime == null)
                {
                    model.ScheduledTime = currentStatePlayView.ScheduledTime;
                }
                if (model.SelectedActorsIds.Count == 0)
                {
                    var playActorsList = _playActorService.GetPlayActorsForPlayId(model.Id);

                    foreach (var playActorRecord in playActorsList)
                    {
                        model.SelectedActorsIds.Add(playActorRecord.ActorId);
                    }
                }

                if (model.File != null)
                {
                    if (model.File.ContentLength > 0 && !model.File.ContentType.Contains("image"))
                    {
                        ModelState.AddModelError(nameof(PlayViewModel.File), "File must be image type!");
                        model.AllActors = _actorService.GetAllActors();
                        return View(model);
                    }

                    var imageFolderPath = Server.MapPath(WebConfigurationManager.AppSettings["imagePath"].ToString());
                    var fileName = Guid.NewGuid().ToString();
                    model.ImageVirtualPath = string.Format("{0}{1}{2}", WebConfigurationManager.AppSettings["virtualImagePath"].ToString(), fileName, Path.GetExtension(model.File.FileName).ToLower());
                    model.ImagePath = string.Format("{0}{1}{2}", imageFolderPath, Path.GetFileName(fileName), Path.GetExtension(model.File.FileName).ToLower());
                    model.File.SaveAs(model.ImagePath);

                    PlayWithActors playWithActors = new PlayWithActors
                    {
                        Title = model.Title,
                        ImagePath = model.ImagePath,
                        ImageVirtualPath = model.ImageVirtualPath,
                        ImageType = Path.GetExtension(model.File.FileName),
                        Description = model.Description,
                        ScheduledTime = model.ScheduledTime,
                        ActorsIds = model.SelectedActorsIds
                    };

                    _playService.UpdatePlay(playWithActors);

                    return RedirectToAction("Index");
                }
                else if (model.File == null)
                {
                    PlayWithActors playWithActors = new PlayWithActors
                    {
                        Id = model.Id,
                        Title = model.Title,
                        ImagePath = currentStatePlayView.ImagePath,
                        ImageVirtualPath = currentStatePlayView.ImageVirtualPath,
                        ImageType = currentStatePlayView.ImageType,
                        Description = model.Description,
                        ScheduledTime = model.ScheduledTime,
                        ActorsIds = model.SelectedActorsIds
                    };

                    _playService.UpdatePlay(playWithActors);

                    return RedirectToAction("Index");
                }
            }
            model.ActorsString = _playViewService.GetPlayView(model.Id).Actors;
            model.AllActors = _actorService.GetAllActors();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var playView = _playViewService.GetPlayView(id);
            var model = new PlayViewModel
            {
                Id = playView.Id,
                Title = playView.Title,
                Description = playView.Description,
                ScheduledTime = playView.ScheduledTime,
                ActorsString = playView.Actors,
                ImageVirtualPath = playView.ImageVirtualPath
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _playService.DeletePlayById(id);
            return Json(new { status = "success", redirectUrl = "/Play" });
        }
    }
    
}