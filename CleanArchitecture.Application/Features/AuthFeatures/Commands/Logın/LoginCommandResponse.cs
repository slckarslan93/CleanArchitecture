namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Logın;
public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    string UserId);