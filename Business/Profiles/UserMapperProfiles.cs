using AutoMapper;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserMapperProfiles : Profile
    {
        public UserMapperProfiles()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, ListUserResponse>();
            CreateMap<User, GetUserResponse>();
        }
    }
}
