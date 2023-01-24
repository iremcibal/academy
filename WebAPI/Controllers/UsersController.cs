using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<ListUserResponse> GetList()
        {
            List<ListUserResponse> result = _userService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetUserResponse GetById(int id)
        {
            GetUserResponse response = _userService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateUserRequest request)
        {
            _userService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateUserRequest request)
        {
            _userService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteUserRequest request)
        {
            _userService.Delete(request);
        }
    }
}
