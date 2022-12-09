using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Application.Common.Mappings;
using PersonManager.Application.Common.Models;
using PersonManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PersonManager.Application.Persons.Queries.GetPersonLinq
{
    public class GetPersonLinqQuery : IRequest<IList<Person>>
    {
    }

    public class GetPersonLinqQueryHandler : IRequestHandler<GetPersonLinqQuery, IList<Person>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonLinqQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<Person>> Handle(GetPersonLinqQuery request, CancellationToken cancellationToken)
        {
            return  (from p in _context.Persons
                     join a in _context.Addresses on p.Id equals a.PersonId
                    select p).ToList();
        }
    }
}
