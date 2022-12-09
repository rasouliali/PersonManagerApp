using AutoMapper;
using AutoMapper.QueryableExtensions;
using PersonManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PersonManager.Application.Common.Dtos;

namespace PersonManager.Application.Addresses.Queries.GetAddresses
{
    public class GetAddressByIdQuery : IRequest<AddressDto>
    {
        public int Id{ get; set; }

    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return
                 await _context.Addresses
                    .AsNoTracking()
                    .Where(r=>r.Id==request.Id)
                    .ProjectTo<AddressDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.City)
                    .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
