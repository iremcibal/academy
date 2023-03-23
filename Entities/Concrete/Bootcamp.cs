using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Bootcamp : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InstructorId { get; set; }
        public int StateId { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual State State { get; set; }    


    }
}
