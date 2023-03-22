using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Employees;
using Business.Requests.Users;
using Business.Responses.Employees;
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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        IMapper _mapper;
        EmployeeBusinessRules _employeeBusinessRules;
        UserBusinessRules _userBusinessRules;
        IUserService _userService;
        public EmployeeManager(IEmployeeDal employeeDal, IMapper mapper, EmployeeBusinessRules employeeBusinessRules, UserBusinessRules userBusinessRules, IUserService userService)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _userBusinessRules = userBusinessRules;
            _userService = userService;
        }

        [ValidationAspect(typeof(UserRequestValidator))]
        [ValidationAspect(typeof(EmployeeRequestValidator))]
        [TransactionAspect]
        public IResult Add(CreateEmployeeRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.createUser.NationalIdentity);
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(request.createUser);
            var user = _userService.Add(createUserRequest);
            Employee employee = _mapper.Map<Employee>(request);
            employee.Id = user.Data.Id;

            _employeeDal.Add(employee);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            _employeeBusinessRules.CheckIfEmployeeNotExist(employee);
            _employeeDal.Delete(employee);

            DeleteUserRequest user = new DeleteUserRequest() { Id =request.Id };
            _userService.Delete(user);

            return new SuccessResult(Messages.DeletedData);

        }

        public IDataResult<GetEmployeeResponse> GetById(int id)
        {
            Employee employee = _employeeDal.Get(e=>e.Id ==id, include: e => e.Include(e => e.User));
            var response = _mapper.Map<GetEmployeeResponse>(employee);
            return new SuccessDataResult<GetEmployeeResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListEmployeeResponse>> GetAll()
        {
            List<Employee> employees = _employeeDal.GetAll(include: e => e.Include(e => e.User));
            List<ListEmployeeResponse> responses = _mapper.Map<List<ListEmployeeResponse>>(employees);
            return new SuccessDataResult<List<ListEmployeeResponse>>(responses,Messages.ListedData);
        }

        [ValidationAspect(typeof(UserRequestValidator))]
        [ValidationAspect(typeof(EmployeeRequestValidator))]
        [TransactionAspect]
        public IResult Update(UpdateEmployeeRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityExist(request.userRequest.NationalIdentity);
            UpdateUserRequest updateUser = _mapper.Map<UpdateUserRequest>(request.userRequest);
            _userService.Update(updateUser);

            Employee employee = _mapper.Map<Employee>(request);
            _employeeDal.Update(employee);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
