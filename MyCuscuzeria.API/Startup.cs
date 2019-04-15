using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using MyCuscuzeria.Infrastructure.Persistence.Repositories;
using MyCuscuzeria.Infrastructure.Transactions;
using Swashbuckle.AspNetCore.Swagger;

namespace MyCuscuzeria.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyCuscuzeriaContext, MyCuscuzeriaContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<INotifiable, Notifiable>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddMvc();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "MyCuscuzeria", Version = "0.0.1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCuscuzeria - 0.0.1");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
