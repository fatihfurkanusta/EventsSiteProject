using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [StringLength(50)]
        public string EventName { get; set; }
        [StringLength(50)]
        public string EventLoc { get; set; }
        [StringLength(200)]
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public bool EventStatus { get; set; }
        public int EventQuota { get; set; }
    }
}
