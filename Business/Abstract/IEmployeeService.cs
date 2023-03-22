using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<GetEmployeeResponse> GetById(int id);
        IDataResult<List<ListEmployeeResponse>> GetAll();
        IResult Add(CreateEmployeeRequest request);
        IResult Delete(DeleteEmployeeRequest request);
        IResult Update(UpdateEmployeeRequest request);
    }
}
