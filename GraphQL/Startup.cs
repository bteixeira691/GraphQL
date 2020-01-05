using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Mongo;
using GraphQL.Repositories;
using GraphQL1.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using GraphQL1.Repositories;

namespace GraphQL
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
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<MongoDBConfig>(Configuration.GetSection(nameof(MongoDBConfig)));
            services.AddSingleton<IMongoDBConfig>(sp =>sp.GetRequiredService<IOptions<MongoDBConfig>>().Value);
            

            services.AddScoped<CustomerReviewRepository>();
            services.AddScoped<CustomerRepository>();


            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CustomerSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = false; })
    .AddGraphTypes(ServiceLifetime.Scoped)
    .AddDataLoader();

          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<CustomerSchema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
