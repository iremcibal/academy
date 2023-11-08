using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CurriculumVitaeId { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }

    }
}
