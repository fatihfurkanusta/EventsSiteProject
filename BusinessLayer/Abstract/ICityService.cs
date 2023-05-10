using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICityService
    {
        List<City> GetList();
        void CityAdd(City city);
        City GetByID(int id);
        void CityDelete(City city);
        void CityUpdate(City city);
    }
}
