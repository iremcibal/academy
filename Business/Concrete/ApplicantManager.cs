using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApplicantManager : IApplicantService
    {
        IApplicantDal _applicantDal;
        IMapper _mapper;
        ApplicantBusinessRules _applicantBusinessRules;
        public ApplicantManager(IApplicantDal applicantDal, IMapper mapper, ApplicantBusinessRules applicantBusinessRules)
        {
            this._applicantDal = applicantDal;
            this._mapper = mapper;
            this._applicantBusinessRules = applicantBusinessRules;
        }

        public void Add(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantBusinessRules.CheckIfApplicantExist(applicant);
            
            _applicantDal.Add(applicant);
        }

        public void Delete(DeleteApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantBusinessRules.CheckIfApplicantNotExist(applicant.Id);

            _applicantDal.Delete(applicant);
        }

        public GetApplicantResponse GetById(int id)
        {
            Applicant applicant = _applicantDal.Get(a=>a.Id== id);
            var response = _mapper.Map<GetApplicantResponse>(applicant);

            return response;
        }

        public List<ListApplicantResponse> GetList()
        {
            List<Applicant> applicants = _applicantDal.GetAll();
            List<ListApplicantResponse> responses = _mapper.Map<List<ListApplicantResponse>>(applicants);

            return responses;

        }

        public void Update(UpdateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            _applicantBusinessRules.CheckIfApplicantNotExist(applicant);

            _applicantDal.Update(applicant);
        }
    }
}
