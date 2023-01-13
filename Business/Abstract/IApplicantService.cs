using Business.Requests.Applicants;
using Business.Responses.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        GetApplicantResponse GetById(int id);
        List<ListApplicantResponse> GetList();
        void Add(CreateApplicantRequest request);
        void Delete(DeleteApplicantRequest request);
        void Update(UpdateApplicantRequest request);
    }
}
