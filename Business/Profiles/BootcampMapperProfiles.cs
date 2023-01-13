using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Requests.Instructors;
using Business.Responses.Bootcamps;
using Business.Responses.Instructors;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BootcampMapperProfiles : Profile
    {
        public BootcampMapperProfiles()
        {

            CreateMap<CreateBootcampRequest, Bootcamp>();
            CreateMap<UpdateBootcampRequest, Bootcamp>();
            CreateMap<DeleteBootcampRequest, Bootcamp>();
            CreateMap<Bootcamp, ListBootcampResponse>();
            CreateMap<Bootcamp, GetBootcampResponse>();
        }
    }
}
