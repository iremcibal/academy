using Business.Abstract;
using Business.Requests.Images;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{getByImageId}")]
        public IActionResult GetById(int imageId)
        {
            var result = _imageService.GetByImageId(imageId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file)
        {
            var result = _imageService.Add(file);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Update(file, image);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] DeleteImageRequest request)
        {
            var result = _imageService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
