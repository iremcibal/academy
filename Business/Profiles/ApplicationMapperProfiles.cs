using AutoMapper;
using Business.Requests.Applications;
using Business.Requests.Blacklists;
using Business.Responses.Applications;
using Business.Responses.Blacklists;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ApplicationMapperProfiles : Profile
    {
        public ApplicationMapperProfiles()
        {
            CreateMap<CreateApplicationRequest, Application>();
            CreateMap<UpdateApplicationRequest, Application>();
            CreateMap<DeleteApplicationRequest, Application>();
            CreateMap<Application, ListApplicationResponse>();
            CreateMap<Application, GetApplicationResponse>();
        }
    }
}
