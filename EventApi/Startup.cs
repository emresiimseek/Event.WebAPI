using Event.Business.Abstract;
using Event.Business.Concete;
using Event.Business.ValidationRules.FluentValidation;
using Event.Core.Abstract;
using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.Core.Utilities.Mapper;
using Event.Data;
using Event.DataAccsess;
using Event.DataAccsess.Abstract;
using Event.DataAccsess.Concrete;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Event.WebAPI.Filters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

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

            services.AddControllers().AddNewtonsoftJson(option =>
 option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventDal, EventDal>();
            services.AddScoped<IServiceResponseModel<Activity>, ServiceResponseModel<Activity>>();
            services.AddScoped(typeof(IService<User>), typeof(UserService));

            //sample
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IServiceResponseModel<Category>, ServiceResponseModel<Category>>();
            services.AddScoped(typeof(IService<Category>), typeof(CategoryService));
            services.AddScoped<ILookUpService<Category>, LookUpService<Category>>();




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

            //fluent validation language
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            //validators
            services.AddTransient<IValidator<UserDto>, UserValidator>();
            services.AddTransient<IValidator<ActivityDto>, ActivityValidator>();

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
