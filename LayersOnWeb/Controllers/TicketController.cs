using BusinessLayer.Contracts;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketService _service;

        public TicketController(ITicketService repo)
        {
            _service = repo;
        }

        [HttpGet("See all tickets")]
        [Authorize(Roles = "Cashier")]
        public List<Ticket> GetAllTicket()
        {
            var result = new List<Ticket>();
            foreach (var t in _service.GetAllTicket())
            {
                result.Add(new Ticket { TicketId = t.TicketId, seatRow = t.seatRow, seatNumber = t.seatNumber, showId = t.showId });
            }
            return result;
        }

        [HttpPost("Sell-Ticket")]
        [Authorize(Roles = "Cashier")]
        public string SellTicket([FromBody] string ShowName, int row, int number)
        {
            if (_service.ShowHasAvailableTickets(ShowName))
            {
                return _service.SellTicket(ShowName, row, number);
            }
            else
                return "There are no ticket available for this show";

        }

        [HttpPost("Cancel Reservation")]
        [Authorize(Roles = "Cashier")]
        public void CancelReservation(string ShowName, int row, int number)
        {
            _service.CancelReservation(ShowName, row, number);
        }

        [HttpPut("Edit Ticket")]
        [Authorize(Roles = "Cashier")]
        public void UpdateTicket([FromBody] TicketEntity ticket)
        {
            _service.UpdateTicket(new TicketModel { TicketId = ticket.TicketId, seatRow = ticket.seatRow, seatNumber = ticket.seatNumber, showId = ticket.showId });
        }
    }
}
