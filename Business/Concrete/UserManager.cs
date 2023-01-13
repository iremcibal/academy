using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _userBusinessRules;
        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public void Add(CreateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserExist(user);
            _userDal.Add(user);
        }

        public void Delete(DeleteUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserNotExist(user);
            _userDal.Delete(user);
        }

        public GetUserResponse GetById(int id)
        {
            User user = _userDal.Get(u=>u.Id == id);
            var response = _mapper.Map<GetUserResponse>(user);
            return response;
        }

        public List<ListUserResponse> GetList()
        {
            List<User> users = _userDal.GetAll();
            List<ListUserResponse> responses = _mapper.Map<List<ListUserResponse>>(users);
            return responses;
        }

        public void Update(UpdateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserNotExist(user);
            _userDal.Update(user);
        }
    }
}
