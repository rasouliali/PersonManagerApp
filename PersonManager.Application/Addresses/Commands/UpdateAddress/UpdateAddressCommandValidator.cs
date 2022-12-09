using PersonManager.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAddressCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

            RuleFor(v => v.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(300).WithMessage("Street must not exceed 300 characters.");
                //.MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        //public async Task<bool> BeUniqueTitle(UpdateAddressCommand model, string title, CancellationToken cancellationToken)
        //{
        //    return await _context.Addresses
        //        .Where(l => l.Id != model.Id)
        //        .AllAsync(l => l.Title != title);
        //}
    }
}
