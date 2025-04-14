
using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.WebApi.Configuration;

public sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
       services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly)); //mediator'ı ekliyoruz

       services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

       services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly); //FluentValidation'ı ekliyoruz validationu otomatik oalrak alicak

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(policy => true));

        });
    }
}
