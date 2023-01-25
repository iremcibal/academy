using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.States;
using Business.Responses.Applicants;
using Business.Responses.States;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _stateService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _stateService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateStateRequest request)
        {
            var result =_stateService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateStateRequest request)
        {
            var result =_stateService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteStateRequest request)
        {
            var result = _stateService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
