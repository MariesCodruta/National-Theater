using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShowRepository : IShowRepository

    {
        private readonly TheatreDbContext _context;

        public ShowRepository(TheatreDbContext context)
        {
            _context = context;
        }

        public ShowEntity GetShow(int Id)
        {
            return _context.ShowEntities.Where(s => s.ShowId == Id).FirstOrDefault();
        }
        public List<ShowEntity> GetAllShows()
        {

            return _context.ShowEntities.ToList();

        }
        public string DeleteShow(int Id)
        {
            var show = GetShow(Id);
            try
            {

                _context.ShowEntities.Remove(show);
                _context.SaveChanges();
                return "Succes";
            }
            catch
            {
                return "Failed";
            }

        }

        public void CreateShow(ShowEntity show)
        {
            _context.ShowEntities.Add(show);
            _context.SaveChanges();
        }


        public void UpdateShow(ShowEntity show)
        {
            _context.Entry(show).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
