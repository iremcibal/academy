﻿using Business.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Instructors
{
    public class CreateInstructorRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public CreateUserRequest CreateUser { get; set; }
    }
}
