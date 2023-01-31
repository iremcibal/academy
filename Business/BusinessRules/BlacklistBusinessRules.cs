using Business.Constants;
using Core.Business.Exceptions;
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
            if (blacklist == null) throw new BusinessException(Messages.BlacklistNotBeExist);
        }

        public void CheckIfBlacklistExist(Blacklist? blacklist)
        {
            if (blacklist != null) throw new BusinessException(Messages.BlacklistAlreadyExist);
        }

        public void CheckIfBlacklistNotExist(int blacklistId)
        {
            Blacklist blacklist = _blacklistDal.Get(b=>b.Id == blacklistId);
            CheckIfBlacklistNotExist(blacklist);
        }

        public void CheckIfBlacklistApplicantExist(int applicantId)
        {
            Blacklist blacklist = _blacklistDal.ApplicationGetByIdInBlacklist(applicantId);
            if (blacklist != null) throw new BusinessException(Messages.HasNotBeAccepted);
        }
    }
}
