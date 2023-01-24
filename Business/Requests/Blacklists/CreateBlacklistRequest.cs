using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Blacklists
{
    public class CreateBlacklistRequest
    {
        public int Id { get; set; }
        public DateTime? date { get; set; }
        public string Reason { get; set; }
        public int ApplicantId { get; set; }
    }
}
