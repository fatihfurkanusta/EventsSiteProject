using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEventService
    {
        List<Event> GetList();
        List<Event> GetListByUser(int id);
        void EventAdd(Event e);
        Event GetByID(int id);
        void EventDelete(Event e);
        void EventUpdate(Event e);
        List<Event> GetListByActive(string search);
    }
}
