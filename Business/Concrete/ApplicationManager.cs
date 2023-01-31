using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Applications;
using Business.Responses.Applications;
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
    public class ApplicationManager : IApplicationService
    {
        IApplicationDal _applicationDal;
        IMapper _mapper;
        ApplicationBusinessRules _applicationBusinessRules;
        BlacklistBusinessRules _blacklistBusinessRules;

        public ApplicationManager(IApplicationDal applicationDal, IMapper mapper, ApplicationBusinessRules applicationBusinessRules, BlacklistBusinessRules blacklistBusinessRules)
        {
            _applicationDal = applicationDal;
            _mapper = mapper;
            _applicationBusinessRules = applicationBusinessRules;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        [ValidationAspect(typeof(ApplicationRequestValidator))]
        public IResult Add(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            _blacklistBusinessRules.CheckIfBlacklistApplicantExist(application.ApplicantId);
            //_applicationBusinessRules.CheckIfApplicationNotExist(application);
            _applicationDal.Add(application);

            return new SuccessResult(Messages.AddedData);
        }

        public IResult Delete(DeleteApplicationRequest request)
        {
            Application application= _mapper.Map<Application>(request);
            _applicationBusinessRules.CheckIfApplicationExist(application);
            _applicationDal.Delete(application);

            return new SuccessResult(Messages.DeletedData);
        }

        public IDataResult<GetApplicationResponse> GetById(int id)
        {
            Application application = _applicationDal.Get(a=>a.Id== id);
            var response = _mapper.Map<GetApplicationResponse>(application);
            return new SuccessDataResult<GetApplicationResponse>(response,Messages.ListedData);
        }

        public IDataResult<List<ListApplicationResponse>> GetList()
        {
            List<Application> applications = _applicationDal.GetAll();
            List<ListApplicationResponse> responses = _mapper.Map<List<ListApplicationResponse>>(applications);
            return new SuccessDataResult<List<ListApplicationResponse>>(responses,Messages.ListedData);
        }

        public IResult Update(UpdateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            _applicationBusinessRules.CheckIfApplicationNotExist(application);
            _applicationDal.Update(application);

            return new SuccessResult(Messages.UpdatedData);
        }
    }
}
