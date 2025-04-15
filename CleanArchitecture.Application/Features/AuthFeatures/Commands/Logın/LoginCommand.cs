using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Logın;
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;