using Business.Abstract;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _applicationService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _applicationService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateApplicationRequest request)
        {
            var result = _applicationService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateApplicationRequest request)
        {
            var result = _applicationService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteApplicationRequest request)
        {
            var result =_applicationService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
