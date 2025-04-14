
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class PersistanceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

        string connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

    }
}
