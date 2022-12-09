using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public string City { get; set; }
        public int PersonId { get; set; }
        public string Street { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new Address();

            entity.City = request.City;
            entity.PersonId = request.PersonId;
            entity.Street = request.Street;

            _context.Addresses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
