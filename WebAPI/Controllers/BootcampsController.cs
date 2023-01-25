using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.Bootcamps;
using Business.Responses.Applicants;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : ControllerBase
    {
        IBootcampService _bootcampService;
        public BootcampsController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _bootcampService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bootcampService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateBootcampRequest request)
        {
            var result = _bootcampService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateBootcampRequest request)
        {
            var result = _bootcampService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBootcampRequest request)
        {
            var result = _bootcampService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
