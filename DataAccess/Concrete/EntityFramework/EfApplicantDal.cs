﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfApplicantDal : EfEntityRepositoryBase<Applicant, AcademyContext>, IApplicantDal
    {
        public Applicant ApplicantGetByIdWithUser(int id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.applicants.Include(i=>i.User).FirstOrDefault(i=> i.User.Id == id);
            }
        }

        public List<Applicant> GetAllWithUser()
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.applicants.Include(i => i.User).ToList();
            }
        }
    }
}
