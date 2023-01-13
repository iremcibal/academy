using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Instructors;
using Business.Responses.Applicants;
using Business.Responses.Instructors;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class InstructorMapperProfiles : Profile
    {
        public InstructorMapperProfiles()
        {

            CreateMap<CreateInstructorRequest, Instructor>();
            CreateMap<UpdateInstructorRequest, Instructor>();
            CreateMap<DeleteInstructorRequest, Instructor>();
            CreateMap<Instructor, ListInstructorResponse>();
            CreateMap<Instructor, GetInstructorResponse>();
        }
    }
}
