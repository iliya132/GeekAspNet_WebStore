using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.DAL;
using WebStore.Models;
using WebStore.Models.Implementations;
using WebStore.Models.Interfaces;

namespace WebStore
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

            services.AddSingleton<IEmployeeDataProvider, InMemoryEmployeeService>();
            services.AddScoped<IProductData, SQLProductData>();
            services.AddDbContext<WebStoreContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            services.AddMvc(i=>i.EnableEndpointRouting=false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //app.UseDefaultFiles();



            app.UseAuthorization();

            app.UseMvc(routes=>
            {
                routes.MapRoute(name: "default", "{Controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
