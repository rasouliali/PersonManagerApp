using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PersonManager.Application.Persons.Queries.GetPersonSQL
{
    public class GetPersonSQLQuery : IRequest<IList<Person>>
    {
    }

    public class GetPersonSQLQueryHandler : IRequestHandler<GetPersonSQLQuery, IList<Person>>
    {
        private readonly IMapper _mapper;
        IApplicationDbContext _context;
        public GetPersonSQLQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<Person>> Handle(GetPersonSQLQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Persons.FromSqlRaw("select * from Persons with(nolock)" +
                " join Addresses with(nolock) on Addresses.PersonId=Persons.Id").ToListAsync();
            return data;
        }
    }
}
