using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationService
    {
        IDataResult<GetApplicationResponse> GetById(int id);
        IDataResult<List<ListApplicationResponse>> GetList();
        IResult Add(CreateApplicationRequest request);
        IResult Delete(DeleteApplicationRequest request);
        IResult Update(UpdateApplicationRequest request);
    }
}
