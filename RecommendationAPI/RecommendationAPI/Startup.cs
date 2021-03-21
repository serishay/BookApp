using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RecommendationAPI.Models;
using RecommendationAPI.Repositories;
using RecommendationAPI.Services;

namespace RecommendationAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",

                builder => builder.AllowAnyOrigin()

                .AllowAnyMethod()

                .AllowAnyHeader()

                );

            });
            services.AddScoped<IRecommendRepository, RecommendRepository>();
            services.AddScoped<IRecommendService, RecommendService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recommend API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recommend API V1");
            });
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ValidateToken(IConfiguration configuration, IServiceCollection services)
        {
            var audienceconfig = configuration.GetSection("Audience");
            var secretkey = audienceconfig["Secret"];
            var keybyteArray = Encoding.ASCII.GetBytes(secretkey);
            var signature = new SymmetricSecurityKey(keybyteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signature,

                ValidateIssuer = true,
                ValidIssuer = audienceconfig["Iss"],

                ValidateAudience = true,
                ValidAudience = audienceconfig["Aud"],

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParameters; });
        }

    }
}
