using AutoMapper;
using Business.Requests.Blacklists;
using Business.Requests.Bootcamps;
using Business.Responses.Blacklists;
using Business.Responses.Bootcamps;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BlacklistMapperProfiles : Profile
    {
        public BlacklistMapperProfiles()
        {
            CreateMap<CreateBlacklistRequest, Blacklist>();
            CreateMap<UpdateBlacklistRequest, Blacklist>();
            CreateMap<DeleteBlacklistRequest, Blacklist>();
            CreateMap<Blacklist, ListBlacklistResponse>();
            CreateMap<Blacklist, GetBlacklistResponse>();
        }
    }
}
