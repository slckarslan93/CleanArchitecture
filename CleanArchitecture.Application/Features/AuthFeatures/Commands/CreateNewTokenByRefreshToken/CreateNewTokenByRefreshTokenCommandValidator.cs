using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("Refresh token is required")
            .Matches("^[a-zA-Z0-9-_.]+$")
            .WithMessage("Refresh token can only contain letters, numbers, dashes, underscores, and periods");
        RuleFor(x => x.UserId).NotEmpty()
            .WithMessage("UserId is required")
            .Matches("^[a-zA-Z0-9-_.]+$")
            .WithMessage("UserId can only contain letters, numbers, dashes, underscores, and periods");
    }
}