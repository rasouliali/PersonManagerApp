using PersonManager.Application.Common.Exceptions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest
    {
        public int Id { get; set; }

        public string FullName { get; set; }

    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
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
