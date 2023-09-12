using BlogEngineApi.Application;
using BlogEngineApi.Application.Interfaces;
using BlogEngineApi.Infra.Cc.Identity.Context;
using BlogEngineApi.Infra.Cc.Identity.Managers;
using BlogEngineApi.Infra.Cc.Identity.Models;
using BlogEngineApi.Infra.Data.Repository.Context;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngineApi.Infra.Cc.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection Services { get; set; }
        private static IConfiguration Configuration { get; set; }

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;

            RegisterContexts();
            RegisterIdentityObjects();
            RegisterAppServices();
            RegisterRepositories();
            RegisterAspNetObjects();
        }

        private static void RegisterContexts()
        {
            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            Services.AddDbContext<IdentityApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Convert.ToInt32(Configuration["Identity:LockoutTimeSpanMinutes"]));
                options.Lockout.MaxFailedAccessAttempts = Convert.ToInt32(Configuration["Identity:MaxFailedAccessAttempts"]);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<IdentityApplicationDbContext>().AddDefaultTokenProviders();
        }

        private static void RegisterAppServices()
        {
            Services.AddTransient<ILoginAppService, LoginAppService>();
        }

        private static void RegisterRepositories()
        {
            //Services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

        //private static void RegisterFilters()
        //{
        //    Services.AddTransient<ValidateBodyParameter>();
        //    Services.AddTransient<ValidateQueryParameters>();
        //}

        private static void RegisterIdentityObjects()
        {
            Services.AddScoped<ApplicationUserManager>();
            Services.AddScoped<SignInManager<ApplicationUser>>();
        }

        private static void RegisterAspNetObjects()
        {
            Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}