
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.Middlewares;
using CleanArchitecture.WebApi.OptionsSetup;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddTransient<ExceptionMiddleware>();

        services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();

        services.ConfigureOptions<JwtOptionsSetup>(); //JWT ayarlarını alır ve ayarlar
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
    }
}
