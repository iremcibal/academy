using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Bootcamps
{
    public class ListBootcampResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InstructorId { get; set; }
        public int StateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Info { get; set; }
    }
}
