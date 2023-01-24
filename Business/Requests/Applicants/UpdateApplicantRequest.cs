using Business.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Applicants
{
    public class UpdateApplicantRequest
    {
        public int Id { get; set; }
        public string About { get; set; }
        public UpdateUserRequest UpdateUser { get; set; }
    }
}
