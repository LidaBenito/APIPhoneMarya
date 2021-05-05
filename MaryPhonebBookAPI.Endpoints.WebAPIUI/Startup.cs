using MaryPhonebBookAPI.Core.Contracts.People;
using MaryPhonebBookAPI.Core.Contracts.Phones;
using MaryPhonebBookAPI.Infra.DAL.Common;
using MaryPhonebBookAPI.Infra.DAL.People;
using MaryPhonebBookAPI.Infra.DAL.Phones;
using MaryPhonebBookAPI.Services.AppService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MaryPhonebBookAPI.Endpoints.WebAPIUI
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc(); 
            services.AddDbContext<MaryaPhoneContext>();
            services.AddControllers();
            services.AddSingleton<IPersonService, PersonService>();

            services.AddSingleton<IPersonRepository, PersonRespository>();
            services.AddSingleton<IPhoneRespository, PhoneRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaryPhonebBookAPI.Endpoints.WebAPIUI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaryPhonebBookAPI.Endpoints.WebAPIUI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
