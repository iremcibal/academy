using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Applicants;
using Business.Requests.Users;
using Business.Responses.Applicants;
using Business.Responses.Users;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApplicantManager : IApplicantService
    {
        IApplicantDal _applicantDal;
        IMapper _mapper;
        ApplicantBusinessRules _applicantBusinessRules;
        UserBusinessRules _userBusinessRules;
        IUserService _userService;
        public ApplicantManager(IApplicantDal applicantDal, IMapper mapper, ApplicantBusinessRules applicantBusinessRules, UserBusinessRules userBusinessRules, IUserService userService)
        {
            this._applicantDal = applicantDal;
            this._mapper = mapper;
            this._applicantBusinessRules = applicantBusinessRules;
            _userBusinessRules = userBusinessRules;
            _userService = userService;
        }

        public void Add(CreateApplicantRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.CreateUser.NationalIdentity);
            CreateUserRequest userRequest = _mapper.Map<CreateUserRequest>(request.CreateUser);
            var user = _userService.Add(userRequest);
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.Id = user.Id;

            _applicantDal.Add(applicant);
        }

        public void Delete(DeleteApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantDal.Delete(applicant);


            DeleteUserRequest userRequest = new DeleteUserRequest() { Id=request.Id};
            _userService.Delete(userRequest);
        }

        public GetApplicantResponse GetById(int id)
        {
            Applicant applicant = _applicantDal.ApplicantGetByIdWithUser(id);
            var response = _mapper.Map<GetApplicantResponse>(applicant);

            return response;
        }

        public List<ListApplicantResponse> GetList()
        {
            List<Applicant> applicants = _applicantDal.GetAllWithUser();
            List<ListApplicantResponse> responses = _mapper.Map<List<ListApplicantResponse>>(applicants);

            return responses;

        }

        public void Update(UpdateApplicantRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityExist(request.UpdateUser.NationalIdentity);
            UpdateUserRequest updateUser = _mapper.Map<UpdateUserRequest>(request.UpdateUser);
            _userService.Update(updateUser);

            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantDal.Update(applicant);
        }
    }
}
