using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class TicketModel
    { 
         public int TicketId { get; set; }
         public int seatRow { get; set; }
         public int seatNumber { get; set; }
         public int showId { get; set; }
     }
}
