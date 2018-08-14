using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.DAL.Views;

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

        public Play GetPlay(Play play)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayRepository.GetById(play.Id);
            }
        }

        public IList<PlayView> GetAllPlays()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var play = _unitOfWork.context.PlayViews;
                return play.ToList();
            }
        }
    }
}
