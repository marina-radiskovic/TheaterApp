using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.DAL.Repositories;

namespace Theater.UnitTests.Repositories
{
    class TestPlayRepository : IRepository<Play>
    {
        public IList<Actor> insertedDummyActors = new List<Actor>();

        public void InsertDummyActors()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                for (int i=1000; i<1005; i++) {
                    var dummyActor = new Actor { ActorId = i, FirstName = "Goran", LastName = "Jevremovic" };
                    _unitOfWork.ActorRepository.InsertActor(dummyActor);
                    _unitOfWork.Save();
                    insertedDummyActors.Add(dummyActor);
                }
            }
        }

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
                _unitOfWork.PlayRepository.GetById(id).Actors.Clear();
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

        public Play InsertDummyPlay()
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                if (_unitOfWork.ActorRepository.GetAll() == null)
                {
                    InsertDummyActors();
                }

                var dummyPlay = new Play
                {
                    Description = "description",
                    Title = "The title",
                    StartDate = DateTime.Today,
                    ImagePath = "gghjkjbj",
                    Actors = _unitOfWork.ActorRepository.GetAll()
                };
                
                _unitOfWork.PlayRepository.Insert(dummyPlay);
                _unitOfWork.Save();
                return _unitOfWork.PlayRepository.GetById(dummyPlay.PlayId);
            }
        }

        public void Clean(IList<int> list)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                foreach (var playId in list)
                {
                    var play = _unitOfWork.PlayRepository.GetById(playId);
                    play.Actors.Clear();
                    _unitOfWork.PlayRepository.DeleteById(playId);
                    _unitOfWork.Save();
                }

                foreach (var actor in insertedDummyActors)
                {
                    _unitOfWork.context.Actors.Attach(actor);
                    _unitOfWork.ActorRepository.DeleteActor(actor);
                    _unitOfWork.Save();
                }
                insertedDummyActors.Clear();
                list.Clear();
            }
        }
    }
}