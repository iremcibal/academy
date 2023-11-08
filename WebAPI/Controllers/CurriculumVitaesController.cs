using Business.Abstract;
using Business.Requests.CurriculumVitae;
using Business.Requests.States;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumVitaesController : ControllerBase
    {

        ICurriculumVitaeService _cvService;
        public CurriculumVitaesController(ICurriculumVitaeService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cvService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cvService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreateCurriculumVitaeRequest request)
        {
            var result = _cvService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateCurriculumVitaeRequest request)
        {
            var result = _cvService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] DeleteCurriculumVitaeRequest request)
        {
            var result = _cvService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
