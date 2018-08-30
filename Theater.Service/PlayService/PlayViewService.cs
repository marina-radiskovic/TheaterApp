using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Views;

namespace Theater.Service.PlayService
{
    public class PlayViewService
    {
        public PlayView GetPlayView(int id)
        {
            using(var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return _unitOfWork.PlayViewRepository.GetPlayView(id);
            }
        }
    }
}
