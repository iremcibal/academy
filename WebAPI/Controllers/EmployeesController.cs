using Business.Abstract;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public List<ListEmployeeResponse> GetList()
        {
            List<ListEmployeeResponse> result = _employeeService.GetList();
            return result;
        }


        [HttpGet("{id}")]
        public GetEmployeeResponse GetById(int id)
        {
            GetEmployeeResponse response = _employeeService.GetById(id);
            return response;
        }

        [HttpPost]
        public void Add(CreateEmployeeRequest request)
        {
            _employeeService.Add(request);
        }

        [HttpPut]
        public void Update(UpdateEmployeeRequest request)
        {
            _employeeService.Update(request);
        }


        [HttpDelete]
        public void Delete([FromBody] DeleteEmployeeRequest request)
        {
            _employeeService.Delete(request);
        }
    }
}
