using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserLoginManager : IUserLoginService
    {
        IUserDal _userDal;

        public UserLoginManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(string userName, string password)
        {
            return _userDal.Get(x=>x.UserEmail == userName && x.Password == password);    
        }
    }
}
