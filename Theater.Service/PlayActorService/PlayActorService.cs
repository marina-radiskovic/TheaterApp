using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;

namespace Theater.Service.PlayActorService
{
    public class PlayActorService
    {
        public void InsertRecord(PlayActor entity)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayActorRepository.Insert(entity);
                _unitOfWork.Save();
            }   
        }

        public IList<PlayActor> GetPlayActorsForPlayId(int id)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayActorRepository.GetPlayActorsForPlayId(id);
            }
        }
    }
}
