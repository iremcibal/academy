using Business.Constants;
using Core.Business.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ApplicantBusinessRules
    {
        IApplicantDal _applicantDal;

        public ApplicantBusinessRules(IApplicantDal applicantDal)
        {
            this._applicantDal = applicantDal;
        }

        public void CheckIfApplicantNotExist(Applicant? applicant)
        {
            if (applicant == null) throw new BusinessException(Messages.ApplicantNotBeExist);
            
        }

        public void CheckIfApplicantExist(Applicant? applicant)
        {
            if (applicant != null) throw new Exception(Messages.ApplicantAlreadyExist);
        }

        public void CheckIfApplicantNotExist(int applicantId)
        {
            Applicant applicant = _applicantDal.Get(a=>a.Id== applicantId);
            CheckIfApplicantNotExist(applicant);
        }

    }

}
