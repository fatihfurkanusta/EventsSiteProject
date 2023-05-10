using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void EventAdd(Event e)
        {
            _eventDal.Insert(e);
        }

        public void EventDelete(Event e)
        {
            _eventDal.Update(e);
        }

        public void EventUpdate(Event e)
        {
            _eventDal.Update(e);
        }

        public bool EventUpdate2(Event e)
        {
            DateTime now = DateTime.Now;
            DateTime x = e.EventDate.AddDays(5);

            if (x.Day < now.Day)
            {
                _eventDal.Update(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Event GetByID(int id)
        {
            return _eventDal.Get(x=>x.EventId == id);
        }

        public List<Event> GetList()
        {
            return _eventDal.List();
        }

        public List<Event> GetListByUser(int id)
        {
            return _eventDal.List(x=> x.UserID == id);
        }

        public List<Event> GetListByActive(string search)
        {
            var value = _eventDal.List(x => x.EventStatus == true);

            if (!string.IsNullOrEmpty(search))
            {
                value = (List<Event>)value.Where(x => x.EventName.Contains(search)).ToList();
            }
            return value;
        }
        public List<Event> GetListByActive()
        {
            var value = _eventDal.List(x => x.EventStatus == true);
            return value;
        }

        public void EventDate()
        {
            List<Event> e = GetList();

            foreach (var item in e)
            {
                if (item.EventDate <= DateTime.Now)
                {
                    item.EventStatus = false;

                    EventUpdate(item);
                }
            }
        }

    }
}
