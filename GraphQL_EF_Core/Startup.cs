using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.GraphQL.GraphTypesExtensions;
using GraphQL_EF_Core.GraphQL.Mutations;
using GraphQL_EF_Core.GraphQL.Queries;
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
                .AddAuthorizeDirectiveType()
                .AddQueryType(descriptor =>
                {
                    descriptor.Name("Queries");
                    descriptor.AddField<PersonQuery>();
                    descriptor.AddField<CityQuery>();
                })
                .AddMutationType(descriptor =>
                {
                    descriptor.Name("Mutations");
                    descriptor.AddField<PersonMutation>();
                    descriptor.AddField<CityMutation>();
                })
                .AddType<CityTypeExtension>() //Add list of people in city
                );


            services.AddAuthorization();
            services.AddAuthentication("GraphQL")
                .AddScheme<Authentication.DummyAuthOptions, Authentication.DummyAuth>("GraphQL", opt => { });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthentication();
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
