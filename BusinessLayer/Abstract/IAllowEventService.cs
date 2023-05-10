using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAllowEventService
    {
        List<AllowEvent> GetList();
        List<AllowEvent> GetListByUser(int id);
        void AllowEventAdd(AllowEvent e);
        AllowEvent GetByID(int id);
        void AllowEventDelete(AllowEvent e);
        void AllowEventUpdate(AllowEvent e);
        List<AllowEvent> GetListByActive(string search);
    }
}
