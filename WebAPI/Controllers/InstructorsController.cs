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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("instructorId")]
        public IActionResult GetById(int instructorId)
        {
            var result = _instructorService.GetById(instructorId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateInstructorRequest request)
        {
            var result = _instructorService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateInstructorRequest request)
        {
            var result = _instructorService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteInstructorRequest request)
        {
            var result =_instructorService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
