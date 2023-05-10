using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AllowEventManager : IAllowEventService
    {
        IAllowEventDal _allowEventDal;

        public AllowEventManager(IAllowEventDal eventDal)
        {
            _allowEventDal = eventDal;
        }

        public void AllowEventAdd(AllowEvent e)
        {
            _allowEventDal.Insert(e);
        }

        public void AllowEventDelete(AllowEvent e)
        {
            e.AllowEventStatus = false;

            _allowEventDal.Update(e);
        }

        public void AllowEventUpdate(AllowEvent e)
        {
            _allowEventDal.Update(e);
        }

        public AllowEvent GetByID(int id)
        {
            return _allowEventDal.Get(x => x.AllowEventId == id);
        }

        public List<AllowEvent> GetList()
        {
            return _allowEventDal.List();
        }
        public List<AllowEvent> GetListOnlyApprove()
        {
            List<AllowEvent> ae =_allowEventDal.List();
            
            List<AllowEvent> newList = new List<AllowEvent>();

            foreach(var item in ae)
            {
                if (item.CheckStatus == false) 
                { 
                    newList.Add(item);
                }
            }

            return newList;
        }

        public List<AllowEvent> GetListByUser(int id)
        {
            return _allowEventDal.List(x => x.UserID == id);
        }

        public List<AllowEvent> GetListByActive(string search)
        {
            var value = _allowEventDal.List(x => x.AllowEventStatus == true);

            if (!string.IsNullOrEmpty(search))
            {
                value = (List<AllowEvent>)value.Where(x => x.AllowEventName.Contains(search)).ToList();
            }
            return value;
        }

        public void CheckAllowEvent() 
        {
            EventManager em = new EventManager(new EfEventDal());

            List<AllowEvent> AllowEventList = GetList();

            foreach (var item in AllowEventList)
            {
                if(item.AllowEventStatus == false)
                {
                    item.AllowEventStatus = true;
                    AllowEventUpdate(item);

                    Event e = new Event();

                    e.EventName = item.AllowEventName;
                    e.EventDate = item.AllowEventDate;
                    e.EventLoc = item.AllowEventLoc ;
                    e.EventDescription = item.AllowEventDescription;
                    e.CategoryID = item.CategoryID;
                    e.UserID = item.UserID;
                    e.EventStatus = true;

                    em.EventAdd(e);
                    
                }
            }
        }
    }
}
