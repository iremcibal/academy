using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.States;
using Business.Responses.Applicants;
using Business.Responses.States;
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
        public List<ListStateResponse> GetList()
        {
            List<ListStateResponse> result = _stateService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetStateResponse GetById(int id)
        {
            GetStateResponse response = _stateService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateStateRequest request)
        {
            _stateService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateStateRequest request)
        {
            _stateService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteStateRequest request)
        {
            _stateService.Delete(request);
        }
    }
}
