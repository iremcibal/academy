using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Blacklists
{
    public class GetBlacklistResponse
    {
        public int Id { get; set; }
        public DateTime? date { get; set; }
        public string Reason { get; set; }
        public int ApplicantId { get; set; }
    }
}
