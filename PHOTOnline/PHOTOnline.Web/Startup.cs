using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PHOTOnline.Business;
using PHOTOnline.Mongo;
using PHOTOnline.Services;
using PHOTOnline.Web.Config;

namespace PHOTOnline.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MongoDBMapperConfiguration.RegisterMapping();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddMongoDatabase(Configuration);
            services.AddPHOTOnlineBusinessServices();
            services.AddPHOTOnlineServices();
            //services.AddAuthorization();
            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy",
                builder => builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .Build()
                );
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseCors("MyCorsPolicy");
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UsePHOTOnlineMvc();
            //app.UsePHOTOnlineSpa(env);
        }
    }
}
