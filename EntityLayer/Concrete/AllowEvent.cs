using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AllowEvent
    {
        [Key]
        public int AllowEventId { get; set; }
        [StringLength(50)]
        public string AllowEventName { get; set; }
        [StringLength(50)]
        public string AllowEventLoc { get; set; }
        [StringLength(200)]
        public string AllowEventDescription { get; set; }
        public DateTime AllowEventDate { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public bool AllowEventStatus { get; set; }
        public bool CheckStatus { get; set; }
        public int AllowEventQuota { get; set; }
    }
}
