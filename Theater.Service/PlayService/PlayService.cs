using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.DAL.DTO;
using Theater.DAL.Views;
using PagedList;
using System.Web.Configuration;
using System.IO;

namespace Theater.Service.PlayService
{
    public class PlayService
    {
        public void DeletePlayById(int id)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayRepository.GetById(id).Actors.Clear();
                _unitOfWork.PlayRepository.DeleteById(id);
                _unitOfWork.Save();
            }
        }

        public int CreatePlay(PlayWithActors playDTO)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                Play play = new Play
                {
                    Title = playDTO.Title,
                    ImagePath = playDTO.ImagePath,
                    ImageVirtualPath = playDTO.ImageVirtualPath,
                    ImageType = playDTO.ImageType,
                    Description = playDTO.Description,
                    ScheduledTime = playDTO.ScheduledTime
                };

                foreach (var id in playDTO.ActorsIds)
                {
                    play.Actors.Add(_unitOfWork.ActorRepository.GetById(id));
                }

                _unitOfWork.PlayRepository.Insert(play);
                _unitOfWork.Save();
                
                return play.PlayId;
            }
        }

        public int UpdatePlay(PlayWithActors playDTO)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var play = _unitOfWork.PlayRepository.GetById(playDTO.Id);
                
                if (playDTO.ScheduledTime == null)
                {
                    playDTO.ScheduledTime = play.ScheduledTime;
                }

                if (playDTO.ActorsIds.Count == 0)
                {
                    foreach (var actor in play.Actors)
                    {
                        playDTO.ActorsIds.Add(actor.ActorId);
                    }
                }

                play.Title = playDTO.Title;
                play.ImagePath = playDTO.ImagePath;
                play.ImageVirtualPath = playDTO.ImageVirtualPath;
                play.ImageType = playDTO.ImageType;
                play.Description = playDTO.Description;
                play.ScheduledTime = playDTO.ScheduledTime;
                play.Actors.Clear();

                foreach (var id in playDTO.ActorsIds)
                {
                    play.Actors.Add(_unitOfWork.ActorRepository.GetById(id));
                }

                _unitOfWork.Save();
                return play.PlayId;
            }
        }

        public Play GetPlay(int id)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayRepository.GetById(id);
            }
        }

        public IList<PlayView> GetAllPlays()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var play = _unitOfWork.context.PlayViews;
                return play.OrderByDescending(x => x.PlayId).ToList();
            }
        }

        public IPagedList<PlayView> GetPlayViewsToPagedList(int? page)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var list = (IEnumerable<PlayView>)_unitOfWork.context.PlayViews.OrderByDescending(x => x.ScheduledTime);
                return list.ToPagedList((page ?? 1), 5);
            }
        }
    }
}
