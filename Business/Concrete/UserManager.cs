using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
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

        public User Add(CreateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserNationalIdentityNotExist(user.NationalIdentity);
            _userDal.Add(user);
            return user;
        }

        public IResult Delete(DeleteUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserNotExist(user);
            _userDal.Delete(user);

            return new SuccessResult(Messages.AddedData);
        }

        public IDataResult<GetUserResponse> GetById(int id)
        {
            User user = _userDal.Get(u=>u.Id == id);
            var response = _mapper.Map<GetUserResponse>(user);
            return new SuccessDataResult<GetUserResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListUserResponse>> GetList()
        {
            List<User> users = _userDal.GetAll();
            List<ListUserResponse> responses = _mapper.Map<List<ListUserResponse>>(users);
            return new SuccessDataResult<List<ListUserResponse>>(responses,Messages.ListedData);
        }

        public IResult Update(UpdateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserNotExist(user);
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
