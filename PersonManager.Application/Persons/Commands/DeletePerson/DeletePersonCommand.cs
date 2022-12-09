using PersonManager.Application.Common.Exceptions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
//using PersonManager.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            _context.Persons.Remove(entity);

            //entity.DomainEvents.Add(new PersonDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
