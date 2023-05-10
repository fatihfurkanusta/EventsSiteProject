using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [StringLength(50)]
        public string TicketNumber { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int? EventID { get; set; }
        public virtual Event e { get; set; }
        public bool EventStatus { get; set; }
    }
}
