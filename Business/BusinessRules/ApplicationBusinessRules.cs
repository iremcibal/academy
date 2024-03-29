﻿using Business.Constants;
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
    public class ApplicationBusinessRules
    {
        IApplicationDal _applicationDal;

        public ApplicationBusinessRules(IApplicationDal applicationDal)
        {
            this._applicationDal = applicationDal;
        }

        public void CheckIfApplicationNotExist(Application? application)
        {
            if (application == null) throw new BusinessException(Messages.ApplicationNotBeExist);
           
        }
        public void CheckIfApplicationExist(Application? application)
        {
            if (application != null) throw new BusinessException(Messages.ApplicationAlreadyExist);
            
        }

        public void CheckIfApplicationNotExist(int applicationId)
        {
            Application application = _applicationDal.Get(a=>a.Id== applicationId);
            CheckIfApplicationNotExist(application);
        }
    }
}
