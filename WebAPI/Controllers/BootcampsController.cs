using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.Bootcamps;
using Business.Responses.Applicants;
using Business.Responses.Bootcamps;
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
        public List<ListBootcampResponse> GetList()
        {
            List<ListBootcampResponse> result = _bootcampService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetBootcampResponse GetById(int id)
        {
            GetBootcampResponse response = _bootcampService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateBootcampRequest request)
        {
            _bootcampService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateBootcampRequest request)
        {
            _bootcampService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteBootcampRequest request)
        {
            _bootcampService.Delete(request);
        }
    }
}
