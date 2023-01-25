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
    public class InstructorBusinessRules
    {
        IInstructorDal _instructorDal;
        public InstructorBusinessRules(IInstructorDal instructorDal)
        {
            this._instructorDal = instructorDal;
        }
        public void CheckIfInstructorNotExist(Instructor? instructor)
        {
            if (instructor == null) throw new BusinessException(Messages.InstructorNotBeExist);
        }
        public void CheckIfInstructorExist(Instructor? instructor)
        {
            if (instructor != null) throw new BusinessException(Messages.InstructorAlreadyExist);
        }
        public void CheckIfInstructorNotExist(int instructorId)
        {
            Instructor instructor = _instructorDal.Get(i=>i.Id == instructorId);
            CheckIfInstructorNotExist(instructor);
        }

    }
}
