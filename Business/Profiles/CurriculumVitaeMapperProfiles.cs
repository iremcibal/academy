using AutoMapper;
using Business.Requests.CurriculumVitae;
using Business.Requests.States;
using Business.Responses.CurriculumVitae;
using Business.Responses.States;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CurriculumVitaeMapperProfiles : Profile
    {
        public CurriculumVitaeMapperProfiles()
        {
            CreateMap<CreateCurriculumVitaeRequest, CurriculumVitae>();
            CreateMap<UpdateCurriculumVitaeRequest, CurriculumVitae>();
            CreateMap<DeleteCurriculumVitaeRequest, CurriculumVitae>();
            CreateMap<CurriculumVitae, ListCurriculumVitaeResponse>();
            CreateMap<CurriculumVitae, GetCurriculumVitaeResponse>();
        }
    }
}
