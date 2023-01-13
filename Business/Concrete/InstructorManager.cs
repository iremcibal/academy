using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;
        InstructorBusinessRules _instructorBusinessRules;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper, InstructorBusinessRules instructorBusinessRules)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public void Add(CreateInstructorRequest request)
        {
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorBusinessRules.CheckIfInstructorExist(ınstructor);
            _instructorDal.Add(ınstructor);
        }

        public void Delete(DeleteInstructorRequest request)
        {
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorBusinessRules.CheckIfInstructorNotExist(ınstructor);
            _instructorDal.Delete(ınstructor);
        }

        public GetInstructorResponse GetById(int id)
        {
            Instructor ınstructor = _instructorDal.Get(i=>i.Id== id);
            var response = _mapper.Map<GetInstructorResponse>(ınstructor);
            return response;
        }

        public List<ListInstructorResponse> GetList()
        {
            List<Instructor> ınstructors = _instructorDal.GetAll();
            List<ListInstructorResponse> responses = _mapper.Map<List<ListInstructorResponse>>(ınstructors);
            return responses;
        }

        public void Update(UpdateInstructorRequest request)
        {
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorBusinessRules.CheckIfInstructorNotExist(ınstructor);
            _instructorDal.Update(ınstructor);
        }
    }
}
