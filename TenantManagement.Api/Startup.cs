using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TenantManagement.InfraStructure.Database;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TenantManagement.Processor.Processor;
using TenantManagement.Processor.Validations;
using TenantManagement.Processor.DbContracts;
using TenantManagement.InfraStructure.Repository;

namespace TenantManagement.Api
{
    public class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory =
        LoggerFactory.Create(
            builder =>
            {
                builder.AddConsole();
            }
        );
        public IConfiguration _config { get; }
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options=> {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddDbContext<TenantDatabase>(op =>
            {
                op.UseSqlServer(_config.GetConnectionString("TenantConnectionString"))
                .UseLoggerFactory(MyLoggerFactory);
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<ITenantProcessor, TenantProcessor>();
            services.AddTransient<ITenantValidator, TenantValidator>();
            services.AddTransient<ITenantQueryRepository, TenantQueryRepository>();
            services.AddTransient<ITenantCommandRepository, TenantCommandRepository>();
            services.AddTransient<IAuthProcessor, AuthProcessor>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TenantManagement.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TenantManagement.Api v1"));
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
