using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Employees;
using Business.Responses.Employees;
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

        public EmployeeManager(IEmployeeDal employeeDal, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public void Add(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            _employeeBusinessRules.CheckIfEmployeeExist(employee);
            _employeeDal.Add(employee);
        }

        public void Delete(DeleteEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            _employeeBusinessRules.CheckIfEmployeeNotExist(employee);
            _employeeDal.Delete(employee);

        }

        public GetEmployeeResponse GetById(int id)
        {
            Employee employee = _employeeDal.Get(e=>e.Id== id);
            var response = _mapper.Map<GetEmployeeResponse>(employee);
            return response;
        }

        public List<ListEmployeeResponse> GetList()
        {
            List<Employee> employees = _employeeDal.GetAll();
            List<ListEmployeeResponse> responses = _mapper.Map<List<ListEmployeeResponse>>(employees);
            return responses;
        }

        public void Update(UpdateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            _employeeBusinessRules.CheckIfEmployeeNotExist(employee);
            _employeeDal.Update(employee);
        }
    }
}
