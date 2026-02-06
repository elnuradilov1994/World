using World.Dtos.Continents;
using FluentValidation;
namespace World.Validators.Continents
{
    public class CreateContinentDtoValidator : AbstractValidator<CreateContinentDto>
    {
        public CreateContinentDtoValidator()
        {
            RuleFor(c=>c.Name).MinimumLength(3).MaximumLength(100);
        }
    }
}
