using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FullName { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person
            {
                FullName = request.FullName,
            };


            _context.Persons.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
