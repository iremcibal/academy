using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Applicants;
using Business.Requests.Users;
using Business.Responses.Applicants;
using Business.Responses.Users;
using Core.Utilities.Results;
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

        public IResult Add(CreateApplicantRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.CreateUser.NationalIdentity);
            CreateUserRequest userRequest = _mapper.Map<CreateUserRequest>(request.CreateUser);
            var user = _userService.Add(userRequest);
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.Id = user.Data.Id;
            _applicantDal.Add(applicant);

            return new SuccessResult(Messages.AddedData) ;
        }

        public IResult Delete(DeleteApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantDal.Delete(applicant);


            DeleteUserRequest userRequest = new DeleteUserRequest() { Id=request.Id};
            _userService.Delete(userRequest);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetApplicantResponse> GetById(int id)
        {
            Applicant applicant = _applicantDal.ApplicantGetByIdWithUser(id);
            var response = _mapper.Map<GetApplicantResponse>(applicant);

            return new SuccessDataResult<GetApplicantResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListApplicantResponse>> GetList()
        {
            List<Applicant> applicants = _applicantDal.GetAllWithUser();
            List<ListApplicantResponse> responses = _mapper.Map<List<ListApplicantResponse>>(applicants);

            return new SuccessDataResult<List<ListApplicantResponse>>(responses,Messages.ListedData);

        }

        public IResult Update(UpdateApplicantRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityExist(request.UpdateUser.NationalIdentity);
            UpdateUserRequest updateUser = _mapper.Map<UpdateUserRequest>(request.UpdateUser);
            _userService.Update(updateUser);

            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantDal.Update(applicant);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
