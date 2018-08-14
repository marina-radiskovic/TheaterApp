using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.DAL.Repositories;

namespace Theater.UnitTests.Repositories
{
    class TestPlayRepository : IRepository<Play>
    {

        public void Delete(Play entity)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.context.Plays.Attach(entity);
                _unitOfWork.PlayRepository.Delete(entity);
                _unitOfWork.Save();
            }
        }

        public void DeleteById(int id)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.context.Plays.Attach(_unitOfWork.PlayRepository.GetById(id));
                _unitOfWork.PlayRepository.DeleteById(id);
                _unitOfWork.Save();
            }
            
        }

        public IList<Play> GetAll()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayRepository.GetAll();
            }
        }

        public Play GetById(int id)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayRepository.GetById(id);
            }
        }

        public void Insert(Play entity)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.PlayRepository.Insert(entity);
                _unitOfWork.Save();
            }
            
        }

        public void Update(Play entity)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                _unitOfWork.context.Plays.Attach(entity);
                _unitOfWork.PlayRepository.Update(entity);
                _unitOfWork.Save();
            }
        }

        public Play GetDummyPlay()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var dummyPlay = new Play();
                dummyPlay.Description = "description";
                dummyPlay.Title = "The title";
                dummyPlay.ScheduledTime = DateTime.Today;
                dummyPlay.Actors = new List<Actor>();
                dummyPlay.ImagePath = "gghjkjbj";

                _unitOfWork.PlayRepository.Insert(dummyPlay);
                _unitOfWork.Save();
                return _unitOfWork.PlayRepository.GetById(dummyPlay.Id);
            }
        }

        public void Clean(IList<int> list)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                foreach (var id in list)
                {
                    _unitOfWork.context.Plays.Attach(_unitOfWork.PlayRepository.GetById(id));
                    _unitOfWork.PlayRepository.DeleteById(id);
                    _unitOfWork.Save();
                }

                list.Clear();
            }
        }
    }
}