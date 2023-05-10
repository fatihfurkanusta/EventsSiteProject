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
    public class CityManager : ICityService
    {
        EfCityDal _cityDal;

        public CityManager(EfCityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void CityAdd(City city)
        {
            throw new NotImplementedException();
        }

        public void CityDelete(City city)
        {
            throw new NotImplementedException();
        }

        public void CityUpdate(City city)
        {
            throw new NotImplementedException();
        }

        public City GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> GetList()
        {
            return _cityDal.List();
        }
    }
}
