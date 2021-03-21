using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AuthenticationService
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
            services.AddControllers();
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",

                builder => builder.AllowAnyOrigin()

                .AllowAnyMethod()

                .AllowAnyHeader()

                );

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            string sqlConnection=Environment.GetEnvironmentVariable("SQL_CONNECTION");
            if(sqlConnection==null){
                sqlConnection = Configuration.GetConnectionString("AuthCon");
            }
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(sqlConnection));
            services.AddScoped<AuthDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
