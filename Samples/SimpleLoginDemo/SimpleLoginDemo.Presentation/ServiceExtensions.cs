﻿// Copyright (C) 2020 Fievus
//
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
using System.Linq;
using System.Reflection;
using Charites.Windows.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Charites.Windows.Samples.SimpleLoginDemo.Presentation
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddControllers(this IServiceCollection services)
            => typeof(AvaloniaController).Assembly.DefinedTypes
                .Concat(typeof(ServiceExtensions).Assembly.DefinedTypes)
                .Where(type => type.GetCustomAttributes<ViewAttribute>(true).Any())
                .Aggregate(services, (s, t) => s.AddTransient(t));
    }
}
