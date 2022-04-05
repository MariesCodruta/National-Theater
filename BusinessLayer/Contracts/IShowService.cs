using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IShowService
    {
        List<ShowModel> GetAllShows();
        ShowEntity GetShow(int Id);
        string DeleteShow(int Id);
        void CreateShow(ShowModel show);
        void UpdateShow(ShowModel show);
    }
}
