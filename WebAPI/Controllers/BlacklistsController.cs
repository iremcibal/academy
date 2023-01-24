using Business.Abstract;
using Business.Requests.Applicants;
using Business.Requests.Blacklists;
using Business.Responses.Applicants;
using Business.Responses.Blacklists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : ControllerBase
    {
        IBlacklistService _blacklistService;
        public BlacklistsController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public List<ListBlacklistResponse> GetList()
        {
            List<ListBlacklistResponse> result = _blacklistService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetBlacklistResponse GetById(int id)
        {
            GetBlacklistResponse response = _blacklistService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateBlacklistRequest request)
        {
            _blacklistService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateBlacklistRequest request)
        {
            _blacklistService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteBlacklistRequest request)
        {
            _blacklistService.Delete(request);
        }
    }
}
