using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;

namespace Theater.Service.ActorService
{
    public class ActorService
    {
        public IList<Actor> GetAllActors()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.ActorRepository.GetAll();
            }
        }

        public Actor GetActorById(int id)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.ActorRepository.GetById(id);
            }
        }
    }
}
