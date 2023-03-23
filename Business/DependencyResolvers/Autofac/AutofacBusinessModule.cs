using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework.Context;
using Core.Utilities.Helpers.FileHelper;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfApplicantDal>().As<IApplicantDal>().SingleInstance();
            builder.RegisterType<EfApplicationDal>().As<IApplicationDal>().SingleInstance();
            builder.RegisterType<EfBlacklistDal>().As<IBlacklistDal>().SingleInstance();
            builder.RegisterType<EfBootcampDal>().As<IBootcampDal>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();
            builder.RegisterType<EfInstructorDal>().As<IInstructorDal>().SingleInstance();
            builder.RegisterType<EfStateDal>().As<IStateDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

            builder.RegisterType<ApplicantManager>().As<IApplicantService>().SingleInstance();
            builder.RegisterType<ApplicationManager>().As<IApplicationService>().SingleInstance();
            builder.RegisterType<BlacklistManager>().As<IBlacklistService>().SingleInstance();
            builder.RegisterType<BootcampManager>().As<IBootcampService>().SingleInstance();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<InstructorManager>().As<IInstructorService>().SingleInstance();
            builder.RegisterType<StateManager>().As<IStateService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();

            builder.RegisterType<ApplicantBusinessRules>().SingleInstance();
            builder.RegisterType<ApplicationBusinessRules>().SingleInstance();
            builder.RegisterType<BlacklistBusinessRules>().SingleInstance();
            builder.RegisterType<BootcampBusinessRules>().SingleInstance();
            builder.RegisterType<EmployeeBusinessRules>().SingleInstance();
            builder.RegisterType<InstructorBusinessRules>().SingleInstance();
            builder.RegisterType<StateBusinessRules>().SingleInstance();
            builder.RegisterType<UserBusinessRules>().SingleInstance();
            builder.RegisterType<ImageBusinessRules>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions
               {
                   Selector = new AspectInterceptorSelector()
               })
               .SingleInstance();
        }

       
}
}
