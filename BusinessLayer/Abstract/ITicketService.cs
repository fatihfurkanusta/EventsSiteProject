using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITicketService
    {
        List<Ticket> GetList();
        List<Ticket> GetListByUser(int id);
        void TicketAdd(Ticket ticket, int userID);
        Ticket GetByID(int id);
        void TicketDelete(Ticket ticket);
        void TicketUpdate(Ticket ticket);
        List<Ticket> GetListByActive(string search);
    }
}
