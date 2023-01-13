using Business.Requests.States;
using Business.Responses.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStateService
    {
        GetStateResponse GetById(int id);
        List<ListStateResponse> GetList();
        void Add(CreateStateRequest request);
        void Delete(DeleteStateRequest request);
        void Update(UpdateStateRequest request);
    }
}
