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
                _unitOfWork.PlayRepository.DeleteById(id);
                _unitOfWork.Save();
            }
        }

        public void DeletePlay(Play play)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayRepository.Delete(play);
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

                _unitOfWork.PlayRepository.Insert(play);

                foreach (var id in playDTO.ActorsIds)
                {
                    PlayActor playActor = new PlayActor
                    {
                        PlayId = play.Id,
                        ActorId = id
                    };
                    _unitOfWork.PlayActorRepository.Insert(playActor);
                }

                _unitOfWork.Save();
                return play.Id;
            }
        }

        public void UpdatePlay(Play play)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayRepository.Update(play);
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
                return play.OrderByDescending(x => x.Id).ToList();
            }
        }

        public IPagedList<PlayView> GetPlayViewsToPagedList(int? page)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var list = (IEnumerable<PlayView>)_unitOfWork.context.PlayViews.OrderByDescending(x => x.ScheduledTime);
                return list.ToPagedList((page ?? 1), 10);
            }
        }
    }
}
