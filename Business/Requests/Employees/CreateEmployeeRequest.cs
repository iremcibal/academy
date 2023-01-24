using Business.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Employees
{
    public class CreateEmployeeRequest
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public CreateUserRequest createUser { get; set; }
    }
}
