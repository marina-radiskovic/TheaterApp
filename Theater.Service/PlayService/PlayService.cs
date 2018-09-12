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

        public bool PlayTimeTaken(DateTime? startDate, DateTime? endDate, TimeSpan? time, TimeSpan? duration)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                //this list won't containt those plays that don't have StartDate or EndDate in particular
                //range, but still overlap with play that has been submited
                //var plays = _unitOfWork.context.Plays.Where(x => x.StartDate >= startDate && x.StartDate <= endDate
                //                                           || x.EndDate >= startDate && x.EndDate <= endDate).ToList();
                //this adds plays that don't have StartDate or EndDate in particular range, 
                // but still overlap with the play that has been submitted
                //plays.AddRange(_unitOfWork.context.Plays.Where(x => x.EndDate >= endDate && x.StartDate <= startDate).ToList());

                var plays = _unitOfWork.context.Plays.Where(x => x.StartDate <= endDate && startDate <= x.EndDate).ToList();

                foreach (var play in plays)
                {
                    var playEndTime = play.Time.Value.Add((TimeSpan)play.Duration);
                    var submitedPlayEndTime = time.Value.Add((TimeSpan)duration);
                    if(play.Time < submitedPlayEndTime && time < playEndTime)
                    {
                        return true;
                    }
                }
                return false;
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
                    StartDate = playDTO.StartDate,
                    EndDate = playDTO.EndDate,
                    Time = playDTO.Time,
                    Duration = playDTO.Duration
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
                playDTO.Canceled = play.Canceled;

                if (play.Canceled == true)
                {
                    if(playDTO.StartDate != null && playDTO.EndDate != null && playDTO.Time != null)
                    {
                        playDTO.Canceled = false;
                    }
                }
                else if(play.Canceled == false)
                {
                    if(playDTO.StartDate == null)
                    {
                        playDTO.StartDate = play.StartDate;
                    }

                    if(playDTO.EndDate == null)
                    {
                        playDTO.EndDate = play.EndDate;
                    }

                    if(playDTO.Time == null)
                    {
                        playDTO.Time = play.Time;
                    }
                }

                if (playDTO.Duration == null)
                {
                    playDTO.Duration = play.Duration;
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
                play.StartDate = playDTO.StartDate;
                play.EndDate = playDTO.EndDate;
                play.Time = playDTO.Time;
                play.Duration = playDTO.Duration;
                play.Canceled = playDTO.Canceled;
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
                var list = (IEnumerable<PlayView>)_unitOfWork.context.PlayViews.OrderBy(x => x.StartDate);
                return list.ToPagedList((page ?? 1), 5);
            }
        }

        public void CancelPlay(int id)
        {
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var play = _unitOfWork.PlayRepository.GetById(id);
                play.Canceled = true;
                play.EndDate = null;
                play.StartDate = null;
                play.Time = null;
                
                _unitOfWork.Save();
            }
        }
    }
}
