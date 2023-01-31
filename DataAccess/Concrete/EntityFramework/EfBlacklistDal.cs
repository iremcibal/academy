using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlacklistDal : EfEntityRepositoryBase<Blacklist, AcademyContext>,IBlacklistDal
    {
        public Blacklist ApplicationGetByIdInBlacklist(int id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.blacklists.Include(i => i.Applicant).FirstOrDefault(i => i.Applicant.Id == id);
            }
        }
    }
}
