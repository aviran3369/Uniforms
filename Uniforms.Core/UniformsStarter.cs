using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uniforms.Core.Route;

namespace Uniforms.Core
{
    public abstract class UniformsStarter
    {
        protected readonly IConfiguration Configuration;
        
        public UniformsStarter(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {

        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {  
            RouterService
                .GetAllRouterManagerImplementations()
                .ForEach(route => app.UseMvc(builder => route.MapRoute(builder)));

        }
    }
}
