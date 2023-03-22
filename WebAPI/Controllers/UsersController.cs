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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateUserRequest request)
        {
            var result =_userService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateUserRequest request)
        {
            var result = _userService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] DeleteUserRequest request)
        {
            var result = _userService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
