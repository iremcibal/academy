using AutoMapper;
using Business.Requests.States;
using Business.Requests.Users;
using Business.Responses.States;
using Business.Responses.Users;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StateMapperProfiles : Profile
    {
        public StateMapperProfiles()
        {
            CreateMap<CreateStateRequest, State>();
            CreateMap<UpdateStateRequest, State>();
            CreateMap<DeleteStateRequest, State>();
            CreateMap<State, ListStateResponse>();
            CreateMap<State, GetStateResponse>();
        }
    }
}
