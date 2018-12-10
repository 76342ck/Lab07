using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Cors;

namespace Lab07
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
            //Configure CORS
            services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:56475/"));
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
                options.AddPolicy("AllowAllMethods",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:56475/")
                                .AllowAnyMethod();
                    });
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:56475/")
                               .AllowAnyHeader();
                    });
                options.AddPolicy("SetPreflightExpiration",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:56475/")
                               .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });

                services.AddMvc();

            //Configure the Web API to accept XML data
            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
            //Configure the JSON serialization to use PascalCase for naming JSON properties
            services.AddMvc()
                .AddJsonOptions(options =>
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure CORS
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:56475/")
           .AllowAnyHeader()
            );

            // Shows UseCors with named policy.
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}
