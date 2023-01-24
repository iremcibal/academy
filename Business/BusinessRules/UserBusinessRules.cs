using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class UserBusinessRules
    {
        IUserDal _userDal;
        public UserBusinessRules(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public void CheckIfUserNotExist(User? user)
        {
            if (user == null) throw new Exception("User not be exist");
        }
        public void CheckIfUserExist(User? user)
        {
            if (user != null) throw new Exception("User already exist");
        }
        public void CheckIfUserNationalIdentityNotExist(string nationalIdentityId)
        {
            User user = _userDal.Get(n => n.NationalIdentity == nationalIdentityId);
            CheckIfUserExist(user);
        }
        public void CheckIfUserNationalIdentityExist(string nationalIdentityId)
        {
            User user = _userDal.Get(n => n.NationalIdentity == nationalIdentityId);
            CheckIfUserNotExist(user);
        }
    }
}
