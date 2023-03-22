using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlacklistService
    {
        IDataResult<GetBlacklistResponse> GetById(int id);
        IDataResult<List<ListBlacklistResponse>> GetAll();
        IResult Add(CreateBlacklistRequest request);
        IResult Delete(DeleteBlacklistRequest request);
        IResult Update(UpdateBlacklistRequest request);
    }
}
