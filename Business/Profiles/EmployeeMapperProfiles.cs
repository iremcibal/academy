using AutoMapper;
using Business.Requests.Employees;
using Business.Requests.Users;
using Business.Responses.Employees;
using Business.Responses.Users;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class EmployeeMapperProfiles : Profile
    {
        public EmployeeMapperProfiles()
        {

            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<UpdateEmployeeRequest, Employee>();
            CreateMap<DeleteEmployeeRequest, Employee>();
            CreateMap<Employee, ListEmployeeResponse>();
            CreateMap<Employee, GetEmployeeResponse>();
        }
    }
}
