using Event.DataAccsess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Event.Core.Abstract;
using Event.Core.Concrete;
using Event.DataAccsess.Abstract;
using Event.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Event.Business.Abstract;
using Event.Entities.Concrete;
using Event.Core.Utilities.Mapper;
using Event.Business.Concete;
using FluentValidation.AspNetCore;
using FluentValidation;
using Event.Entities.DTOs;
using Event.Business.ValidationRules.FluentValidation;
using Event.WebAPI.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Event.Core.Helpers;

namespace EventApi
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

            services.AddDbContextPool<EventContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("MySqlConStr"), o => { o.MigrationsAssembly("Event.DataAccsess"); });
            });



            //DI Configurations

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<DbContext, EventContext>();
            services.AddScoped(typeof(IUserDal), typeof(UserDal));
            services.AddScoped(typeof(IService<User>), typeof(UserService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IAutoMapper), typeof(AutoMapperBase));
            services.AddScoped(typeof(IsExistFilter<>));
            services.AddScoped<IApplicationUser, ApplicationUser>();



            //jwt
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //configuration jwt Authentication

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //fluent validation

            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation();

            services.AddTransient<IValidator<UserDto>, UserValidator>();


            //idendity


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
