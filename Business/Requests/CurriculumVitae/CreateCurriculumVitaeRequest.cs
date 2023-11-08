using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.CurriculumVitae
{
    public class CreateCurriculumVitaeRequest
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string LicanceDegree { get; set; }
        public string Skills { get; set; }
    }
}
