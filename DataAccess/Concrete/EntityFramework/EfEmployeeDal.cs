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
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, AcademyContext>, IEmployeeDal
    {
        public Employee EmployeeGetByIdWithUser(int id)
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.employees.Include(i => i.User).FirstOrDefault(i => i.User.Id == id);
            }
        }
        public List<Employee> GetAllWithUser()
        {
            using (AcademyContext context = new AcademyContext())
            {
                return context.employees.Include(i=> i.User).ToList();
            }
        }
    }
}
