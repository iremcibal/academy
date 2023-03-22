using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applications
{
    public class ListApplicationResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantUserFirstName { get; set; }
        public string ApplicantUserLastName { get; set; }
        public string ApplicantUserEmail { get; set; }
        public int BootcampId { get; set; }
        public string BootcampName { get; set; }
        public int StateId { get; set; }
        public string StateInfo { get; set; }
    }
}
