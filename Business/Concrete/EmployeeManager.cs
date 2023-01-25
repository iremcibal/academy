using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Employees;
using Business.Requests.Users;
using Business.Responses.Employees;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(CreateEmployeeRequest request)
        {
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(request.createUser.NationalIdentity);
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(request.createUser);
            var user = _userService.Add(createUserRequest);
            Employee employee = _mapper.Map<Employee>(request);
            employee.Id = user.Id;

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
            Employee employee = _employeeDal.EmployeeGetByIdWithUser(id);
            var response = _mapper.Map<GetEmployeeResponse>(employee);
            return new SuccessDataResult<GetEmployeeResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListEmployeeResponse>> GetList()
        {
            List<Employee> employees = _employeeDal.GetAllWithUser();
            List<ListEmployeeResponse> responses = _mapper.Map<List<ListEmployeeResponse>>(employees);
            return new SuccessDataResult<List<ListEmployeeResponse>>(responses,Messages.ListedData);
        }

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
