using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.Blacklists;
using Business.Responses.Applicants;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : ControllerBase
    {
        IBlacklistService _blacklistService;
        public BlacklistsController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _blacklistService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _blacklistService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateBlacklistRequest request)
        {
            var result = _blacklistService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateBlacklistRequest request)
        {
            var result = _blacklistService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBlacklistRequest request)
        {
            var result = _blacklistService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
