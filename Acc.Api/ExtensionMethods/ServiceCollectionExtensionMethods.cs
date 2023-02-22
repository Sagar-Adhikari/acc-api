using Acc.Api.Data;
using Acc.Api.Repositories;
using Acc.Api.Repositories.Interfaces;
using Acc.Api.Services;
using Acc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Acc.Api.ExtensionMethods;

public static class ServiceCollectionExtensionMethods
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddPooledDbContextFactory<AccDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"))
                .UseSnakeCaseNamingConvention();
        });
    }

    public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                // options.Cookie.Domain = "";
                options.SlidingExpiration = true;
            });
        
        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IAccountUserRepository, AccountUserRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAccountUserService, AccountUserService>()
            .AddScoped<IAuthService, AuthService>();

    }

    public static IServiceCollection ConfigureExternalDependencies(this IServiceCollection services)
    { 
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        return services.AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddAutoMapper(typeof(Program));
    }

    public static IServiceCollection ConfigureMvc(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        return services;
    }
    
} 