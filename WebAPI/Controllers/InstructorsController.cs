using Business.Abstract;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public List<ListInstructorResponse> GetList()
        {
            List<ListInstructorResponse> result = _instructorService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetInstructorResponse GetById(int id)
        {
            GetInstructorResponse response = _instructorService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateInstructorRequest request)
        {
            _instructorService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateInstructorRequest request)
        {
            _instructorService.Update(request);
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] DeleteInstructorRequest request)
        {
            _instructorService.Delete(request);
        }
    }
}
