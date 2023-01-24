using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
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

        public void Add(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Add(bootcamp);
        }

        public void Delete(DeleteBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Delete(bootcamp);
        }

        public GetBootcampResponse GetById(int id)
        {
            Bootcamp bootcamp = _bootcampDal.Get(b=>b.Id== id);
            var response = _mapper.Map<GetBootcampResponse>(bootcamp);
            return response;
        }

        public List<ListBootcampResponse> GetList()
        {
            List<Bootcamp> bootcamps = _bootcampDal.GetAll();
            List<ListBootcampResponse> responses = _mapper.Map<List<ListBootcampResponse>>(bootcamps);
            return responses;
        }

        public void Update(UpdateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            _bootcampBusinessRules.CheckIfBootcampNotExist(bootcamp);
            _bootcampDal.Update(bootcamp);
        }
    }
}
