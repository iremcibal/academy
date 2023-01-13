using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BlacklistBusinessRules
    {
        IBlacklistDal _blacklistDal;
        public BlacklistBusinessRules(IBlacklistDal blacklistDal)
        {
            this._blacklistDal = blacklistDal;
        }

        public void CheckIfBlacklistNotExist(Blacklist? blacklist)
        {
            if (blacklist == null) throw new Exception("Blacklist not be exist");
        }

        public void CheckIfBlacklistExist(Blacklist? blacklist)
        {
            if (blacklist != null) throw new Exception("Blacklist already exist");
        }

        public void CheckIfBlacklistNotExist(int blacklistId)
        {
            Blacklist blacklist = _blacklistDal.Get(b=>b.Id == blacklistId);
            CheckIfBlacklistNotExist(blacklist);
        }
    }
}
