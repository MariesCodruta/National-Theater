using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IShowRepository
    {
        //toate metodele care le implementez in clasa repository
        void CreateShow(ShowEntity show);
        string DeleteShow(int Id);
        List<ShowEntity> GetAllShows();
        ShowEntity GetShow(int Id);
        void UpdateShow(ShowEntity show);
    }
}
