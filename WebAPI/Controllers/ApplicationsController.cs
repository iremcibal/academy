using Business.Abstract;
using Business.Requests.Applications;
using Business.Responses.Applications;
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

        [HttpGet]
        public List<ListApplicationResponse> GetList()
        {
            List<ListApplicationResponse> result = _applicationService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetApplicationResponse GetById(int id)
        {
            GetApplicationResponse response = _applicationService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateApplicationRequest request)
        {
            _applicationService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateApplicationRequest request)
        {
            _applicationService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteApplicationRequest request)
        {
            _applicationService.Delete(request);
        }
    }
}
