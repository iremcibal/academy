using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.CurriculumVitae;
using Business.Responses.CurriculumVitae;
using Business.Responses.Images;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CurriculumVitaeManager : ICurriculumVitaeService
    {
        ICurriculumVitaeDal _cvDal;
        IMapper _mapper;
        CVBusinessRules _businessRules;

        public CurriculumVitaeManager(ICurriculumVitaeDal cvDal, IMapper mapper, CVBusinessRules businessRules)
        {
            _cvDal = cvDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public IResult Add(CreateCurriculumVitaeRequest request)
        {
            CurriculumVitae curriculumVitae = _mapper.Map<CurriculumVitae>(request);
            //_businessRules.CheckIfBootcampNotExist(curriculumVitae);
            _cvDal.Add(curriculumVitae);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteCurriculumVitaeRequest request)
        {
            CurriculumVitae curriculumVitae = _mapper.Map<CurriculumVitae>(request);
            _cvDal.Delete(curriculumVitae);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<List<ListCurriculumVitaeResponse>> GetAll()
        {
            List<CurriculumVitae> curriculumVitae = _cvDal.GetAll();
            List<ListCurriculumVitaeResponse> responses = _mapper.Map<List<ListCurriculumVitaeResponse>>(curriculumVitae);
            return new SuccessDataResult<List<ListCurriculumVitaeResponse>>(responses);
        }

        public IDataResult<GetCurriculumVitaeResponse> GetById(int id)
        {
            CurriculumVitae curriculumVitae = _cvDal.Get(ci => ci.Id == id);
            GetCurriculumVitaeResponse response = _mapper.Map<GetCurriculumVitaeResponse>(curriculumVitae);
            return new SuccessDataResult<GetCurriculumVitaeResponse>(response, Messages.ListedData);
        }

        public IResult Update(UpdateCurriculumVitaeRequest request)
        {
            CurriculumVitae curriculumVitae = _mapper.Map<CurriculumVitae>(request);
            _cvDal.Update(curriculumVitae);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
