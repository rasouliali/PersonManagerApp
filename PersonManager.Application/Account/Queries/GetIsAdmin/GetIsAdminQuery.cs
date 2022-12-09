using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PersonManager.Application.Account.Queries.Dto;
using PersonManager.Application.Common.Interfaces;
using PersonManager.Application.Common.Mappings;
using PersonManager.Application.Common.Models;
using PersonManager.Application.Common.Security;
using MediatR;

namespace PersonManager.Application.Account.Queries.GetIsAdmin
{

    [Authorize(Roles = "role_admin")]
    public class GetIsAdminQuery : IRequest<IsAdminDto>
    {
    }

    public class GetIsAdminQueryHandler : IRequestHandler<GetIsAdminQuery, IsAdminDto>
    {
        private readonly IMapper _mapper;

        public GetIsAdminQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IsAdminDto> Handle(GetIsAdminQuery request, CancellationToken cancellationToken)
        {
            return new IsAdminDto { IsAdmin = true };
        }

    }
}
