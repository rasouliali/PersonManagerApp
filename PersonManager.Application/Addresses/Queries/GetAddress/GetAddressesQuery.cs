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
    public class GetAddressesQuery : IRequest<IList<AddressDto>>
    {
    }

    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, IList<AddressDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<AddressDto>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            return
                 await _context.Addresses
                    .AsNoTracking()
                    .ProjectTo<AddressDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.City)
                    .ToListAsync(cancellationToken);
        }
    }
}
