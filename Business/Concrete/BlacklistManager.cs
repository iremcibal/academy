using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        [ValidationAspect(typeof(BlacklistRequestValidator))]
        public IResult Add(CreateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
            _blacklistDal.Add(blacklist);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
            _blacklistDal.Delete(blacklist);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetBlacklistResponse> GetById(int id)
        {
            Blacklist blacklist = _blacklistDal.Get(b=>b.Id == id, include: b => b.Include(b => b.Applicant));
            var response = _mapper.Map<GetBlacklistResponse>(blacklist);

            return new SuccessDataResult<GetBlacklistResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListBlacklistResponse>> GetAll()
        {
            List<Blacklist> blacklists = _blacklistDal.GetAll(include: b => b.Include(b => b.Applicant.User));
            List<ListBlacklistResponse> responses = _mapper.Map<List<ListBlacklistResponse>>(blacklists);

            return new SuccessDataResult<List<ListBlacklistResponse>>(responses,Messages.ListedData);
        }

        public IResult Update(UpdateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            _blacklistBusinessRules.CheckIfBlacklistNotExist(blacklist);
            _blacklistDal.Update(blacklist);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
