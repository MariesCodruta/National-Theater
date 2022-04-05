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
    public class TicketService : ITicketService
    {
        public readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public List<TicketModel> GetAllTicket()
        {
            List<TicketModel> result = new List<TicketModel>();
            foreach (var s in _ticketRepository.GetAllTicket())
            {
                result.Add(new TicketModel { TicketId = s.TicketId,seatRow=s.seatRow,seatNumber=s.seatNumber,showId=s.showId });
            }
            return result;
        }
        public string CancelReservation(string ShowName, int row, int number)
        {
            return _ticketRepository.CancelReservation(ShowName, row, number);
        }

         public bool IsTicketAvailable(string showName, int row, int number)
         {
             return _ticketRepository.IsTicketAvailable(showName, row, number);
         }

        public string SellTicket(string ShowName, int row, int number)
        {
             var available = _ticketRepository.IsTicketAvailable(ShowName, row, number);
             if (available)
             {
                 _ticketRepository.SellTicket(ShowName, row, number);
                 return "Ticket sold successfully";
             }
             else
             {
                 return "Ticket is not available! Please choose another row and seat number";
             }    
            return _ticketRepository.SellTicket(ShowName, row, number);
        }

        public bool ShowHasAvailableTickets(string ShowName)
        {
            return _ticketRepository.ShowHasAvailableTickets(ShowName);
        }

        public void UpdateTicket(TicketModel ticket)
        {
            _ticketRepository.UpdateTicket(new TicketEntity { TicketId = ticket.TicketId, seatRow = ticket.seatRow, seatNumber = ticket.seatNumber, showId = ticket.showId });
        }
    }
}
