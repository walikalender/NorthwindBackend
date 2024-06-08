﻿using Castle.DynamicProxy;
using MessageProject.Core.Utilities.Interceptors.Autofac;
using MessageProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProject.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect(int interval) : MethodInterception
    {
        private readonly int _interval = interval;
        private readonly Stopwatch _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                Debug.WriteLine(message: $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}--> {_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
