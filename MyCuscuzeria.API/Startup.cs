using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyCuscuzeria.API.Security;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using MyCuscuzeria.Infrastructure.Persistence.Repositories;
using MyCuscuzeria.Infrastructure.Transactions;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace MyCuscuzeria.API
{
    public class Startup
    {
        private const string AUDIENCE = "c1f51f42";
        private const string ISSUER = "c6bbbb645024";

        public void ConfigureServices(IServiceCollection services)
        {
            //IoC (Injeção de dependências)
            services.AddScoped<MyCuscuzeriaContext, MyCuscuzeriaContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<INotifiable, Notifiable>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Services (IoC)
            services.AddTransient<IAccompanimentService, AccompanimentService>();
            services.AddTransient<IBeverageService, BeverageService>();
            services.AddTransient<ICuscuzService, CuscuzService>();
            services.AddTransient<ICuscuzeiroService, CuscuzeiroService>();
            services.AddTransient<IDrinkService, DrinkService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPromoService, PromoService>();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IUserService, UserService>();

            //Repositories (IoC)
            services.AddTransient<IAccompanimentRepository, AccompanimentRepository>();
            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<ICuscuzRepository, CuscuzRepository>();
            services.AddTransient<ICuscuzeiroRepository, CuscuzeiroRepository>();
            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPromoRepository, PromoRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            #region Token Configurations

            //Token Configurations
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString())
            };
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                //Valida a assinatura do token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                //Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                //Tempo de tolerância para a expiração de um token
                //(utilizado caso haja problemas de sincronismo de horário entre
                //diferentes computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            //Ativa o uso do token como forma ce autorizar o acesso aos recursos
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            //Para todas as requisições serem requeridas (token), e o endpoint não exigir o token,
            //será necessário colocar o [AllowAnonymous]
            //Caso remova essa linha, para todas as requisições que precisarem de token,
            //será necessário colocar [Authorize("Bearer")]
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            #endregion

            services.AddCors();
            //services.AddMvc();

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

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCuscuzeria - 0.0.1");
            });
        }
    }
}
