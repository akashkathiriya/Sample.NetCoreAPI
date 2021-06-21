using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SampleNetCore.Common.IServices;
using SampleNetCore.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleNetCore.API
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IManageJsonData, ManageJsonData>();
        }
    }
}
