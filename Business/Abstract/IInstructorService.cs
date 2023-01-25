using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        IDataResult<GetInstructorResponse> GetById(int id);
        IDataResult<List<ListInstructorResponse>> GetList();
        IResult Add(CreateInstructorRequest request);
        IResult Delete(DeleteInstructorRequest request);
        IResult Update(UpdateInstructorRequest request);
    }
}
