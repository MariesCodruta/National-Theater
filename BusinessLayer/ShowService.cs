using BusinessLayer.Contracts;
using DataAccess;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShowService : IShowService
    {
        public readonly IShowRepository _showRepository;
        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }
        public void CreateShow(ShowModel show)
        {
            _showRepository.CreateShow(new ShowEntity { ShowId = show.ShowId, GenreEntity = (GenreEntity)show.GenreModel, Title = show.Title, DistributionList = show.DistributionList, ShowDate = show.ShowDate, NumberOfTickets = show.NumberOfTickets });
        }
        public string DeleteShow(int Id)
        {
            return _showRepository.DeleteShow(Id);
        }

        public List<ShowModel> GetAllShows()
        {
            List<ShowModel> result = new List<ShowModel>();
            foreach(var s in _showRepository.GetAllShows())
            {
              result.Add(new ShowModel { ShowId = s.ShowId,GenreModel= (GenreModel)s.GenreEntity, Title = s.Title, DistributionList = s.DistributionList, ShowDate = s.ShowDate, NumberOfTickets = s.NumberOfTickets });
            }
            return result;
        }

        public ShowEntity GetShow(int Id)
        {
             return _showRepository.GetShow(Id);
        }

        public void UpdateShow(ShowModel show)
        {
            _showRepository.UpdateShow(new ShowEntity { ShowId = show.ShowId,GenreEntity= (GenreEntity)show.GenreModel, Title = show.Title, DistributionList = show.DistributionList, ShowDate = show.ShowDate, NumberOfTickets = show.NumberOfTickets });
        }
    }
}
