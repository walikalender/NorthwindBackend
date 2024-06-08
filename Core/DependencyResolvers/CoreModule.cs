using MessageProject.Core.CrossCuttingConcerns.Caching;
using MessageProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using MessageProject.Core.CrossCuttingConcerns.Caching.Redis;
using MessageProject.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options => options.Configuration="localhost:1453");
            services.AddSingleton<ICacheManager,RedisCacheManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
