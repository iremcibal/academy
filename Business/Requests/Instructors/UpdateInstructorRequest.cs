using Business.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Instructors
{
    public class UpdateInstructorRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int cvId { get; set; }
        public UpdateUserRequest updateUserRequest { get; set; }
    }
}
