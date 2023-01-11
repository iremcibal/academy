using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blacklist : IEntity
    {
        public int Id { get; set; }
        public DateTime? date { get; set; }
        public string Reason { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
