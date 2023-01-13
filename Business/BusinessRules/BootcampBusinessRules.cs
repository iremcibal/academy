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
            if (bootcamp == null) throw new Exception("Bootcamp not be exist");

        }
        public void CheckIfBootcampExist(Bootcamp? bootcamp) 
        {
            if (bootcamp != null) throw new Exception("Bootcamp already exist");
        }

        public void CheckIfBootcampNotExist(int bootcampId)
        {
            Bootcamp bootcamp = _bootcampDal.Get(b=>b.Id== bootcampId);
            CheckIfBootcampNotExist(bootcamp);
        }
    }
}
