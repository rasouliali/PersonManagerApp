using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Application.Common.Mappings;
using PersonManager.Application.Common.Models;
using MediatR;

namespace PersonManager.Application.Persons.Queries.GetPersonsWithPagination
{
    public class GetPersonsWithPaginationQuery : IRequest<PaginatedList<PersonBriefDto>>
    {
        public string FullName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetPersonsWithPaginationQueryHandler : IRequestHandler<GetPersonsWithPaginationQuery, PaginatedList<PersonBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PersonBriefDto>> Handle(GetPersonsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Persons
                .Where(x => x.FullName.Contains(request.FullName))
                .OrderBy(x => x.FullName)
                .ProjectTo<PersonBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
