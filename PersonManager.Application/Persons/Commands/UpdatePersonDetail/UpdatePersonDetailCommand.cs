using PersonManager.Application.Common.Exceptions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Persons.Commands.UpdatePersonDetail
{
    public class UpdatePersonDetailCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class UpdatePersonDetailCommandHandler : IRequestHandler<UpdatePersonDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.FullName = request.FullName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
