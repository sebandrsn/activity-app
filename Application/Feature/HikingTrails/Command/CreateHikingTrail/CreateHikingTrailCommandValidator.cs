using FluentValidation;

namespace ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail
{
    public class CreateHikingTrailCommandValidator : AbstractValidator<CreateHikingTrailCommand>
    {
        public CreateHikingTrailCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Description)
                .MaximumLength(50)
                .WithMessage("{PropertyName} too long") ;
        }
    }
}
