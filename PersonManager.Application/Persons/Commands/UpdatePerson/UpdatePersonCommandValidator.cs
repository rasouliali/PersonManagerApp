using FluentValidation;

namespace PersonManager.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(v => v.FullName)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
