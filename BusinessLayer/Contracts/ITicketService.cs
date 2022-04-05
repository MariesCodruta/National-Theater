using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ITicketService
    {
        List<TicketModel> GetAllTicket();
        string SellTicket(string ShowName, int row, int number);
        string CancelReservation(string ShowName, int row, int number);
        void UpdateTicket(TicketModel ticket);
        bool ShowHasAvailableTickets(string ShowName);
        bool IsTicketAvailable(string showName, int row, int number);
    }
}
