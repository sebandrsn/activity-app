using ActivityApp.Application.Common.Validation;
using FluentValidation;

namespace ActivityApp.Application.Feature.HikingTrails.Command.CreateHikingTrail
{
    public class CreateHikingTrailCommandValidator : AbstractValidator<CreateHikingTrailCommand>
    {
        private IValidationService _validationService;

        public CreateHikingTrailCommandValidator(IValidationService validationService)
        {
            _validationService = validationService;

            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MaximumLength(30)
                .WithMessage("{PropertyName} too long, maximum length 30")
                .Must(_validationService.AllCharIsLetter)
                .WithMessage("{PropertyName} can only contain letters");
            RuleFor(p => p.Description)
                .MaximumLength(100)
                .WithMessage("{PropertyName} too long, maximum length 100") ;
        }
    }
}
