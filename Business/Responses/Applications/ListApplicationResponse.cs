﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applications
{
    public class ListApplicationResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int StateId { get; set; }
    }
}
