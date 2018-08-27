using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.DAL.Views;
using PagedList;

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

        public void InsertPlay(Play play)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayRepository.Insert(play);
                _unitOfWork.Save();
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

        public IPagedList<PlayView> GetPlayViewsToPagedList(int? pageNumber)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var list = (IEnumerable<PlayView>)_unitOfWork.context.PlayViews.OrderByDescending(x => x.ScheduledTime);
                return list.ToPagedList((pageNumber ?? 1), 3);
            }
        }
    }
}
