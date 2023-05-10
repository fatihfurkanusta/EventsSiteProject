using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string UserSurname { get; set; }
        [StringLength(200)]
        public string UserEmail { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        public bool UserStatus { get; set; }
    }   
}
