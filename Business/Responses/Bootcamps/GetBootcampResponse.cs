using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Bootcamps
{
    public class GetBootcampResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InstructorId { get; set; }
        public int StateId { get; set; }
        public int ImageId { get; set; }
        public string ImageImagePath { get; set; }
        public string InstructorUserFirstName { get; set; }
        public string InstructorUserLastName { get; set; }
        public string StateInfo { get; set; }
    }
}
