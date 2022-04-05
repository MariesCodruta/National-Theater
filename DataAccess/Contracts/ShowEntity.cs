using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
   
   public class ShowEntity
    {
       
        [Key]
        public int ShowId { get; set; }
        public GenreEntity GenreEntity { get; set; }
        public String Title { get; set; }
        public String DistributionList { get; set; }
        public DateTime ShowDate { get; set; }
        public int NumberOfTickets { get; set; }
        public ICollection<TicketEntity> TicketEntities { get; set; }
    }
}
