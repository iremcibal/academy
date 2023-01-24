using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Instructors;
using Business.Requests.Users;
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
        UserBusinessRules _userBusinessRules;
        IUserService _userService;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper, InstructorBusinessRules instructorBusinessRules, UserBusinessRules userBusinessRules, IUserService userService)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
            _instructorBusinessRules = instructorBusinessRules;
            _userBusinessRules = userBusinessRules;
            _userService = userService;
        }

        public void Add(CreateInstructorRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.CreateUser.NationalIdentity);
            CreateUserRequest userRequest = _mapper.Map<CreateUserRequest>(request.CreateUser);
            var user = _userService.Add(userRequest);
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            ınstructor.Id = user.Id;
            _instructorDal.Add(ınstructor);
        }

        public void Delete(DeleteInstructorRequest request)
        {
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorDal.Delete(ınstructor);

            DeleteUserRequest userRequest = new DeleteUserRequest() { Id = request.Id };
            _userService.Delete(userRequest);
        }

        public GetInstructorResponse GetById(int id)
        {
            Instructor ınstructor = _instructorDal.InstructorGetByIdWithUser(id);
            var response = _mapper.Map<GetInstructorResponse>(ınstructor);
            return response;
        }

        public List<ListInstructorResponse> GetList()
        {
            List<Instructor> ınstructors = _instructorDal.GetAllWithUser();
            List<ListInstructorResponse> responses = _mapper.Map<List<ListInstructorResponse>>(ınstructors);
            return responses;
        }

        public void Update(UpdateInstructorRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityExist(request.updateUserRequest.NationalIdentity);
            UpdateUserRequest updateUser = _mapper.Map<UpdateUserRequest>(request.updateUserRequest);
            _userService.Update(updateUser);

            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorDal.Update(ınstructor);
        }
    }
}
