using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketDal _ticketDal;
        EventManager em = new EventManager(new EfEventDal());

        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public Ticket GetByID(int id)
        {
            return _ticketDal.Get(x => x.TicketId == id);
        }

        public List<Ticket> GetList()
        {
            return _ticketDal.List();   
        }

        public List<Ticket> GetListByActive(string search)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetListByUser(int id)
        {
            return _ticketDal.List(x => x.UserID == id);
        }

        public void TicketAdd(Ticket p, int userID)
        {
            p.UserID = userID;
            p.EventStatus = true;
            p.TicketNumber = RandomTicketNumber();
            _ticketDal.Insert(p);

            var item = em.GetByID((int)p.EventID);
            item.EventQuota -= 1;
            em.EventUpdate(item);
            
        }

        public void TicketDelete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void TicketUpdate(Ticket ticket)
        {
            _ticketDal.Update(ticket);
        }

        public string RandomTicketNumber() 
        {
            {
                const int passwordLength = 8;
                const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

                Random randNum = new Random();

                StringBuilder password = new StringBuilder(passwordLength);
                for (int i = 0; i < passwordLength; i++)
                {
                    int index = randNum.Next(0, allowedChars.Length);
                    password.Append(allowedChars[index]);
                }

                return password.ToString();
            }
        }

        public bool CheckTicket(Ticket t) 
        {
            List<Ticket> ticketList = GetList();

            foreach (var item in ticketList) 
            {
                if (item.TicketNumber == t.TicketNumber) 
                {
                    if (item.EventStatus == true) 
                    { 
                        return true;
                    }
                }
            }
            return false;
        }

        public void TicketDate() 
        {
            List<Ticket> t = GetList();

            foreach(var item in t)
            {
                if (item.e.EventDate >= DateTime.Now)
                {
                    item.EventStatus = false;

                    TicketUpdate(item);
                }
            }
        }

    }
}
