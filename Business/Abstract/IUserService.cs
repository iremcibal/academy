using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<GetUserResponse> GetById(int id);
        IDataResult<List<ListUserResponse>> GetAll();
        IDataResult<User> Add(CreateUserRequest request);
        IResult Delete(DeleteUserRequest request);
        IResult Update(UpdateUserRequest request);
    }
}
