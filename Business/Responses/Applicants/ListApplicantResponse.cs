using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applicants
{
    public class ListApplicantResponse
    {
        public int Id { get; set; }
        public string About { get; set; }
        public ListUserResponse User { get; set; }
    
}
}
