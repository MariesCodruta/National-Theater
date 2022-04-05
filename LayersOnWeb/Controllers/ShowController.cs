using BusinessLayer.Contracts;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _service;

        public ShowController(IShowService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<Show> GetAllShows()
        {
            var result = new List<Show>();
            foreach(var s in _service.GetAllShows())
            {
                result.Add(new Show {ShowId=s.ShowId,Genre= (Genre)s.GenreModel,Title=s.Title,DistributionList=s.DistributionList,ShowDate=s.ShowDate,NumberOfTickets=s.NumberOfTickets});
            }
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ShowEntity GetShow(int id)
        {
            return _service.GetShow(id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteShow(int id)
        {
            _service.DeleteShow(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] Show show)
        {
            _service.CreateShow(new ShowModel { ShowId = show.ShowId, GenreModel = (GenreModel)show.Genre, Title = show.Title, DistributionList = show.DistributionList, ShowDate = show.ShowDate, NumberOfTickets = show.NumberOfTickets });
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put([FromBody] Show show)
        {
            _service.UpdateShow(new ShowModel { ShowId = show.ShowId,GenreModel= (GenreModel)show.Genre, Title = show.Title, DistributionList = show.DistributionList, ShowDate = show.ShowDate, NumberOfTickets = show.NumberOfTickets });
        }
    }
}

