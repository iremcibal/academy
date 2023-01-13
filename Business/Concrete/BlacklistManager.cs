using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlacklistManager : IBlacklistService
    {
        IBlacklistDal _blacklistDal;
        IMapper _mapper;
        BlacklistBusinessRules _blacklistBusinessRules;

        public BlacklistManager(IBlacklistDal blacklistDal, IMapper mapper, BlacklistBusinessRules blacklistBusinessRules)
        {
            _blacklistDal = blacklistDal;
            _mapper = mapper;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public void Add(CreateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistExist(blacklist);
            _blacklistDal.Add(blacklist);
        }

        public void Delete(DeleteBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
            _blacklistDal.Delete(blacklist);
        }

        public GetBlacklistResponse GetById(int id)
        {
            Blacklist blacklist = _blacklistDal.Get(b=>b.Id == id);
            var response = _mapper.Map<GetBlacklistResponse>(blacklist);
            return response;
        }

        public List<ListBlacklistResponse> GetList()
        {
            List<Blacklist> blacklists = _blacklistDal.GetAll();
            List<ListBlacklistResponse> responses = _mapper.Map<List<ListBlacklistResponse>>(blacklists);
            return responses;
        }

        public void Update(UpdateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
            _blacklistDal.Update(blacklist);
        }
    }
}
