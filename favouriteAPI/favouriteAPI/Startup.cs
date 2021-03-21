using favouriteAPI.Models;
using favouriteAPI.Repository;
using favouriteAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace favouriteAPI
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
            this.ValidateToken(Configuration, services);
            services.AddScoped<IFavouriteRepo, FavouriteRepo>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddDbContext<FavouriteDbContext>();
            services.AddMvc();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Favourite API", Version = "v1" });
            //});

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
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Favourite API V1");
            });

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
