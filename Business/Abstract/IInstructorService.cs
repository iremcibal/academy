using Business.Requests.Instructors;
using Business.Responses.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorService
    {
        GetInstructorResponse GetById(int id);
        List<ListInstructorResponse> GetList();
        void Add(CreateInstructorRequest request);
        void Delete(DeleteInstructorRequest request);
        void Update(UpdateInstructorRequest request);
    }
}
