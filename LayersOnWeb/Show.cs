using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class Show
    {
        
        public int ShowId { get; set; }
        
        public Genre Genre { get; set; }
      
        public String Title { get; set; }
       
        public String DistributionList { get; set; }
       
        public DateTime ShowDate { get; set; }
       
        public int NumberOfTickets { get; set; }
      
        public ICollection<Ticket> Tickets { get; set; }
    }
}
