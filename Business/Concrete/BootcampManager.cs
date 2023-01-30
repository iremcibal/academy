using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BootcampManager : IBootcampService
    {
        IBootcampDal _bootcampDal;
        IMapper _mapper;
        BootcampBusinessRules _bootcampBusinessRules;
        public BootcampManager(IBootcampDal bootcampDal, IMapper mapper, BootcampBusinessRules bootcampBusinessRules)
        {
            _bootcampDal = bootcampDal;
            _mapper = mapper;
            _bootcampBusinessRules = bootcampBusinessRules;
        }

        [ValidationAspect(typeof(BootcampRequestValidator))]
        public IResult Add(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Add(bootcamp);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Delete(bootcamp);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetBootcampResponse> GetById(int id)
        {
            Bootcamp bootcamp = _bootcampDal.Get(b=>b.Id== id);
            var response = _mapper.Map<GetBootcampResponse>(bootcamp);

            return new SuccessDataResult<GetBootcampResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListBootcampResponse>> GetList()
        {
            List<Bootcamp> bootcamps = _bootcampDal.GetAll();
            List<ListBootcampResponse> responses = _mapper.Map<List<ListBootcampResponse>>(bootcamps);

            return new SuccessDataResult<List<ListBootcampResponse>>(responses,Messages.ListedData);
        }

        public IResult Update(UpdateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Update(bootcamp);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
