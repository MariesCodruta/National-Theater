using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ITicketRepository
    {
        string SellTicket(string ShowName, int row, int number);
        string CancelReservation(string ShowName, int row, int number);
        void UpdateTicket(TicketEntity ticket);
        bool IsTicketAvailable(string showName, int row, int number);
        bool ShowHasAvailableTickets(string showName);
        List<TicketEntity> GetAllTicket();
    }
}
