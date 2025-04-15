using CleanArchitecture.Application.Features.AuthFeatures.Commands.Logın;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
public sealed record CreateNewTokenByRefreshTokenCommand(string UserId, string RefreshToken) : IRequest<LoginCommandResponse>;