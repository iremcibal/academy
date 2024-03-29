﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Instructors;
using Business.Requests.Users;
using Business.Responses.Instructors;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
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

        [ValidationAspect(typeof(UserRequestValidator))]
        [ValidationAspect(typeof(InstructorRequestValidator))]
        [TransactionAspect]
        public IResult Add(CreateInstructorRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.CreateUser.NationalIdentity);
            CreateUserRequest userRequest = _mapper.Map<CreateUserRequest>(request.CreateUser);
            var user = _userService.Add(userRequest);
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            ınstructor.Id = user.Data.Id;
            _instructorDal.Add(ınstructor);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteInstructorRequest request)
        {
            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorDal.Delete(ınstructor);

            DeleteUserRequest userRequest = new DeleteUserRequest() { Id = request.Id };
            _userService.Delete(userRequest);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetInstructorResponse> GetById(int id)
        {
            Instructor ınstructor = _instructorDal.Get(i=>i.Id== id,include:i=>i.Include(i=>i.User).Include(i => i.CurriculumVitae));
            var response = _mapper.Map<GetInstructorResponse>(ınstructor);
            return new SuccessDataResult<GetInstructorResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListInstructorResponse>> GetAll()
        {
            List<Instructor> ınstructors = _instructorDal.GetAll(include: i => i.Include(i => i.User).Include(i=>i.CurriculumVitae));
            List<ListInstructorResponse> responses = _mapper.Map<List<ListInstructorResponse>>(ınstructors);
            return new SuccessDataResult<List<ListInstructorResponse>>(responses,Messages.ListedData);
        }
        [ValidationAspect(typeof(UserRequestValidator))]
        [ValidationAspect(typeof(InstructorRequestValidator))]
        [TransactionAspect]
        public IResult Update(UpdateInstructorRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityExist(request.updateUserRequest.NationalIdentity);
            UpdateUserRequest updateUser = _mapper.Map<UpdateUserRequest>(request.updateUserRequest);
            _userService.Update(updateUser);

            Instructor ınstructor = _mapper.Map<Instructor>(request);
            _instructorDal.Update(ınstructor);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
