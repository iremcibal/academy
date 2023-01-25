using Business.Requests.States;
using Business.Responses.States;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStateService
    {
        IDataResult<GetStateResponse> GetById(int id);
        IDataResult<List<ListStateResponse>> GetList();
        IResult Add(CreateStateRequest request);
        IResult Delete(DeleteStateRequest request);
        IResult Update(UpdateStateRequest request);
    }
}
