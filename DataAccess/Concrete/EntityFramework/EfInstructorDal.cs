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
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, AcademyContext>, IInstructorDal
    {
        public List<Instructor> GetAllWithUser()
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.instructors.Include(i=>i.User).ToList();
            }
        }

        public Instructor InstructorGetByIdWithUser(int id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.instructors.Include(i => i.User).FirstOrDefault(i => i.User.Id == id);
            }
        }
    }
}
