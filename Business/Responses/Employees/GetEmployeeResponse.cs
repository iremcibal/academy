﻿using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Employees
{
    public class GetEmployeeResponse
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public GetUserResponse User { get; set; }
    }
}
