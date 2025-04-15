using CleanArchitecture.Application.Features.AuthFeatures.Commands.Logın;
using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

internal class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}