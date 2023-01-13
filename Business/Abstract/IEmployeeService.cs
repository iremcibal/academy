using Business.Requests.Employees;
using Business.Responses.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        GetEmployeeResponse GetById(int id);
        List<ListEmployeeResponse> GetList();
        void Add(CreateEmployeeRequest request);
        void Delete(DeleteEmployeeRequest request);
        void Update(UpdateEmployeeRequest request);
    }
}
