using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ibge.Domain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

                services.AddDbContext<DataContext>(opt => opt
                .UseSqlServer(Configuration.GetConnectionString("desenvolvimento")));

                services.AddScoped<IRegionRepository, RegionRepository>();
                //TODO: Implements query ibge
                //TODO: Implements integration handler
                // services.AddScoped<IRegionIbgeRepository, RegionIbgeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
