using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TheatreDbContext _context;

        public TicketRepository(TheatreDbContext context)
        {
            _context = context;
        }

        public List<TicketEntity> GetAllTicket()
        {
            return _context.TicketEntities.ToList();
        }
        private int GetShowIdFromShowName(string ShowName)
        {
            var show = _context.ShowEntities.Where(x => x.Title == ShowName).FirstOrDefault();
            return show.ShowId;
        }

        public string SellTicket(string ShowName, int row, int number)
        {
            try
            {
                var ticket = new TicketEntity();
                ticket.seatRow = row;
                ticket.seatNumber = number;
                ticket.showId = GetShowIdFromShowName(ShowName);
                _context.TicketEntities.Add(ticket);
                _context.SaveChanges();
                Updatenumberofticket(ShowName);
                return "Reservation made successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //update in tabela de show 
        private void Updatenumberofticket(string ShowName)
        {
            var result = _context.ShowEntities.SingleOrDefault(b => b.Title == ShowName);
            if (result != null)
            {
                result.NumberOfTickets--;
                _context.SaveChanges();
            }
        }

        public bool ShowHasAvailableTickets(string showName)
        {
            var NrOfTicket = (from s in _context.ShowEntities
                              where s.Title == showName
                              select s.NumberOfTickets).FirstOrDefault();
            return NrOfTicket > 0;
        }

        //cancel reservation
        public string CancelReservation(string ShowName, int row, int number)
        {

            try
            {
                var showId = GetShowIdFromShowName(ShowName);
                var ticket = _context.TicketEntities.First(x => x.seatNumber == number && x.seatRow == row && x.showId == showId);
                _context.TicketEntities.Remove(ticket);
                _context.SaveChanges();
                UpdateNumberOfTicketAfterCancelReservation(ShowName);
                return "Reservation made successfully";
            }
            catch
            {
                return "Failed";
            }
        }

        private void UpdateNumberOfTicketAfterCancelReservation(string ShowName)
        {
            var result = _context.ShowEntities.SingleOrDefault(b => b.Title == ShowName);
            if (result != null)
            {
                result.NumberOfTickets++;
                _context.SaveChanges();
            }
        }

        //edit reserved seat
        public void UpdateTicket(TicketEntity ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool IsTicketAvailable(string showName, int row, int number)
       {
           var ticket = (from t in _context.TicketEntities
                         join s in _context.ShowEntities on t.showId equals s.ShowId
                         where t.seatRow == row && t.seatNumber == number && s.Title == showName
                         select t.TicketId).FirstOrDefault();
           if (ticket != null && ticket > 0)
               return false;
           return true;
       }
    }
}
