namespace CleanArchitecture.WebApi.Configuration;

public sealed class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
     .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly); //controller'ların bulunduğu assembly'i ekliyoruz (artik presenrarion katmaninda olacak controller lar)

        services.AddOpenApi();
    }
}