using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Instructors
{
    public class ListInstructorResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
    }
}
