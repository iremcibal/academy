using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBootcampService
    {
        IDataResult<GetBootcampResponse> GetById(int id);
        IDataResult<List<ListBootcampResponse>> GetList();
        IResult Add(CreateBootcampRequest request);
        IResult Delete(DeleteBootcampRequest request);
        IResult Update(UpdateBootcampRequest request);
    }
}
