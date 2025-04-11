using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commmands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
          .NotNull().WithMessage("Name cannot be null.")
          .MinimumLength(3)
          .WithMessage("Name must be at least 3 characters long.");

        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.")
          .NotNull().WithMessage("Model cannot be null.")
          .MinimumLength(3)
          .WithMessage("Model must be at least 3 characters long.");

        RuleFor(x => x.EnginePower).NotEmpty().WithMessage("EnginePower is required.")
            .NotNull().WithMessage("EnginePower cannot be null.")
            .GreaterThan(0)
            .WithMessage("EnginePower must be greater than 0.");
    }
}