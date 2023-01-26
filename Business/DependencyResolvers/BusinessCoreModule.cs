using Core.DependencyResolvers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class BusinessCoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddAutoMapper(assemblies: AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
