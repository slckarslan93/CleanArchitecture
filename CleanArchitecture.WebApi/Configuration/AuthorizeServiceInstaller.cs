
namespace CleanArchitecture.WebApi.Configuration;

public sealed class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();
    }
}
