using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Application : IEntity
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int StateId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual State State { get; set; }

    }
}
