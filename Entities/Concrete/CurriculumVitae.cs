using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CurriculumVitae : IEntity
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string LicanceDegree { get; set; }
        public string Skills { get; set; }
    }
}
