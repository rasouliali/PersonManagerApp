using PersonManager.Application.Common.Exceptions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }

            _context.Addresses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
