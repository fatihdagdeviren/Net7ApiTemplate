﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AppendMediatR(this IServiceCollection services)
        {      
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
        }
    }
}
