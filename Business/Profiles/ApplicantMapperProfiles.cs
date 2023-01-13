using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Responses.Applicants;
using Business.Responses.Employees;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ApplicantMapperProfiles : Profile
    {
        public ApplicantMapperProfiles()
        {
            CreateMap<CreateApplicantRequest, Applicant>();
            CreateMap<UpdateApplicantRequest, Applicant>();
            CreateMap<DeleteApplicantRequest, Applicant>();
            CreateMap<Applicant, ListApplicantResponse>();
            CreateMap<Applicant, GetApplicantResponse>();
        }
    }
}
