using Business.Requests.Users;
using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applicants
{
    public class GetApplicantResponse
    {
        public int Id { get; set; }
        public string About { get; set; }
        public GetUserResponse User { get; set; }
    }
}
