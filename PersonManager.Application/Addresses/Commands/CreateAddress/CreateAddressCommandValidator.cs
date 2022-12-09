using PersonManager.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters.");
            RuleFor(v => v.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(300).WithMessage("Street must not exceed 300 characters.");
        }

        //public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        //{
        //    return await _context.Addresses
        //        .AllAsync(l => l.Title != title);
        //}
    }
}
