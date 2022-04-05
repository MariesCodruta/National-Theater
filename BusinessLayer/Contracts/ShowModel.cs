using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
   public class ShowModel
    {
        public int ShowId { get; set; }
        public GenreModel GenreModel { get; set; }
        public String Title { get; set; }
        public String DistributionList { get; set; }
        public DateTime ShowDate { get; set; }
        public int NumberOfTickets { get; set; }
        public ICollection<TicketModel> TicketModels { get; set; }

    }
}


