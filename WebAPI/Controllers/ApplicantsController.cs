using Business.Abstract;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        IApplicantService _applicantService;
        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public List<ListApplicantResponse> GetList()
        {
            List<ListApplicantResponse> result = _applicantService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetApplicantResponse GetById(int id)
        {
            GetApplicantResponse response = _applicantService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateApplicantRequest request)
        {
            _applicantService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateApplicantRequest request)
        {
            _applicantService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteApplicantRequest request)
        {
            _applicantService.Delete(request);
        }
    }
}
