using Business.Abstract;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
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
        public IActionResult GetList()
        {
            var result = _applicantService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _applicantService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateApplicantRequest request)
        {
            var result = _applicantService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateApplicantRequest request)
        {
            var result = _applicantService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteApplicantRequest request)
        {
            var result = _applicantService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
