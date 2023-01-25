using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        IDataResult<GetApplicantResponse> GetById(int id);
        IDataResult<List<ListApplicantResponse>> GetList();
        IResult Add(CreateApplicantRequest request);
        IResult Delete(DeleteApplicantRequest request);
        IResult Update(UpdateApplicantRequest request);
    }
}
