using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IApplicantDal, EfApplicantDal>();
            services.AddSingleton<ApplicantBusinessRules>();
            services.AddSingleton<IApplicantService, ApplicantManager>();

            services.AddSingleton<IApplicationDal,EfApplicationDal>();
            services.AddSingleton<ApplicationBusinessRules>();
            services.AddSingleton<IApplicationService, ApplicationManager>();

            services.AddSingleton<IBlacklistDal,EfBlacklistDal>();
            services.AddSingleton<BlacklistBusinessRules>();
            services.AddSingleton<IBlacklistService,BlacklistManager>();

            services.AddSingleton<IBootcampDal,EfBootcampDal>();
            services.AddSingleton<BootcampBusinessRules>();
            services.AddSingleton<IBootcampService, BootcampManager>();

            services.AddSingleton<IEmployeeDal,EfEmployeeDal>();
            services.AddSingleton<EmployeeBusinessRules>();
            services.AddSingleton<IEmployeeService, EmployeeManager>();

            services.AddSingleton<IInstructorDal,EfInstructorDal>();
            services.AddSingleton<InstructorBusinessRules>();
            services.AddSingleton<IInstructorService, InstructorManager>();

            services.AddSingleton<IStateDal,EfStateDal>();
            services.AddSingleton<StateBusinessRules>();
            services.AddSingleton<IStateService, StateManager>();

            services.AddSingleton<IUserDal,EfUserDal>();
            services.AddSingleton<UserBusinessRules>();
            services.AddSingleton<IUserService, UserManager>();

            return services;
        }
    }
}
