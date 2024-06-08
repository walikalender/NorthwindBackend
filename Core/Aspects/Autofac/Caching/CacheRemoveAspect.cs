using Castle.DynamicProxy;
using MessageProject.Core.CrossCuttingConcerns.Caching;
using MessageProject.Core.Utilities.Interceptors.Autofac;
using MessageProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect(string pattern) : MethodInterception
    {
        private readonly string _pattern = pattern;
        private readonly ICacheManager _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
