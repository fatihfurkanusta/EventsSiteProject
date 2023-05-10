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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public User GetByID(int id)
        {
            return _userDal.Get(x=>x.UserID == id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void UserAdd(User user)
        {
            user.UserStatus = true;
            _userDal.Insert(user);
        }
        public bool UserAdd2(User user)
        {
            user.UserStatus = true;

            List<User> list = GetList();


            if (list.Any(x => x.UserEmail == user.UserEmail))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void UserDelete(User user)
        {
            user.UserStatus = false;
            _userDal.Update(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }
    }
}
