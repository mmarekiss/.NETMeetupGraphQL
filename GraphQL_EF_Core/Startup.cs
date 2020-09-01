using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.GraphQL;
using GraphQL_EF_Core.GraphQL.GraphTypes;
using GraphQL_EF_Core.GraphQL.Mutations;
using GraphQL_EF_Core.Helpers;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GraphQL_EF_Core
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
           .CreateLogger();

            services.AddDbContext<QLContext>(opt =>
            {
                opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=graphQL_test;Trusted_Connection=True;ConnectRetryCount=0");
            }, ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddMediatR(typeof(Startup).Assembly);

            services.AddGraphQL(SchemaBuilder.New()
                .AddQueryType(descriptor =>
                {
                    descriptor.AddField<CityQuery>("City");
                    descriptor.AddField<PersonQuery>("People");
                })
                .AddMutationType(descriptor =>
                {
                    descriptor.Name("Mutations");
                    
                    descriptor.AddField<PersonMutation>("PersonMutation");
                    descriptor.AddField<CityMutation>("CityMutation");
                })
                .AddType<CityTypeExtension>()
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
