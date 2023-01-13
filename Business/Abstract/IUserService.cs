using Business.Requests.Users;
using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        GetUserResponse GetById(int id);
        List<ListUserResponse> GetList();
        void Add(CreateUserRequest request);
        void Delete(DeleteUserRequest request);
        void Update(UpdateUserRequest request);
    }
}
