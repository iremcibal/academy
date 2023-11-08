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
    public class CVBusinessRules
    {
        ICurriculumVitaeDal _cvDal;
        public CVBusinessRules(ICurriculumVitaeDal cvDal)
        {
            this._cvDal = cvDal;
        }

        public void CheckIfCurriculumVitaeNotExist(CurriculumVitae? CurriculumVitae)
        {
            if (CurriculumVitae == null) throw new BusinessException(Messages.CurriculumVitaeNotBeExist);

        }
        public void CheckIfCurriculumVitaeExist(CurriculumVitae? CurriculumVitae)
        {
            if (CurriculumVitae != null) throw new BusinessException(Messages.CurriculumVitaeAlreadyExist);
        }

        public void CheckIfBootcampNotExist(int cvId)
        {
            CurriculumVitae curriculumVitae = _cvDal.Get(b => b.Id == cvId);
            CheckIfCurriculumVitaeNotExist(curriculumVitae);
        }
    }
}
