using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PersonManager.Application.Persons.Queries.GetPersonLambda
{
    public class GetPersonLambdaQuery : IRequest<IList<Person>>
    {
    }

    public class GetPersonLambdaQueryHandler : IRequestHandler<GetPersonLambdaQuery, IList<Person>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPersonLambdaQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<Person>> Handle(GetPersonLambdaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Persons.Include(c=>c.Addresses).ToListAsync();
        }
    }
}
