using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            //services.AddSingleton<IMailService, MailKitMailService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<Stopwatch>();
            //services.AddMemoryCache();
            //services.AddSingleton<ICacheManager, MemoryCacheManager>();
            //services.AddSingleton<FileLogger>();
            //services.AddSingleton<MongoDbLogger>();
        }
    }
}
