using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBootcampService
    {
        GetBootcampResponse GetById(int id);
        List<ListBootcampResponse> GetList();
        void Add(CreateBootcampRequest request);
        void Delete(DeleteBootcampRequest request);
        void Update(UpdateBootcampRequest request);
    }
}
