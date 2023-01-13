using Business.Requests.Applications;
using Business.Responses.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicationService
    {
        GetApplicationResponse GetById(int id);
        List<ListApplicationResponse> GetList();
        void Add(CreateApplicationRequest request);
        void Delete(DeleteApplicationRequest request);
        void Update(UpdateApplicationRequest request);
    }
}
