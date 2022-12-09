using FluentValidation;

namespace PersonManager.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(v => v.FullName)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
