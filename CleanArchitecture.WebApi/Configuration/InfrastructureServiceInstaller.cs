using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Infrastructure.Authantication;

namespace CleanArchitecture.WebApi.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
    }
}