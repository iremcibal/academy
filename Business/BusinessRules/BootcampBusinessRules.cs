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
    public class BootcampBusinessRules
    {
        IBootcampDal _bootcampDal;
        public BootcampBusinessRules(IBootcampDal bootcampDal)
        {
            this._bootcampDal = bootcampDal;
        }

        public void CheckIfBootcampNotExist(Bootcamp? bootcamp)
        {
            if (bootcamp == null) throw new BusinessException(Messages.BootcampNotBeExist);

        }
        public void CheckIfBootcampExist(Bootcamp? bootcamp) 
        {
            if (bootcamp != null) throw new BusinessException(Messages.BootcampAlreadyExist);
        }

        public void CheckIfBootcampNotExist(int bootcampId)
        {
            Bootcamp bootcamp = _bootcampDal.Get(b=>b.Id== bootcampId);
            CheckIfBootcampNotExist(bootcamp);
        }
    }
}
