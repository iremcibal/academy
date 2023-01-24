using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Applications;
using Business.Responses.Applications;
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

        public ApplicationManager(IApplicationDal applicationDal, IMapper mapper, ApplicationBusinessRules applicationBusinessRules)
        {
            _applicationDal = applicationDal;
            _mapper = mapper;
            _applicationBusinessRules = applicationBusinessRules;
        }

        public void Add(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            _applicationBusinessRules.CheckIfApplicationNotExist(application);
            _applicationDal.Add(application);
        }

        public void Delete(DeleteApplicationRequest request)
        {
            Application application= _mapper.Map<Application>(request);
            _applicationBusinessRules.CheckIfApplicationExist(application);
            _applicationDal.Delete(application);
        }

        public GetApplicationResponse GetById(int id)
        {
            Application application = _applicationDal.Get(a=>a.Id== id);
            var response = _mapper.Map<GetApplicationResponse>(application);
            return response;
        }

        public List<ListApplicationResponse> GetList()
        {
            List<Application> applications = _applicationDal.GetAll();
            List<ListApplicationResponse> responses = _mapper.Map<List<ListApplicationResponse>>(applications);
            return responses;
        }

        public void Update(UpdateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            _applicationBusinessRules.CheckIfApplicationNotExist(application);
            _applicationDal.Update(application);
        }
    }
}
