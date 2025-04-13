using CleanArchitecture.Application.Features.AuthFeatures.Commands.Logın;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

namespace CleanArchitecture.Application.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
}