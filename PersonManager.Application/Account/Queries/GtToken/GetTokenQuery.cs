//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using CleanArchitecture.Application.Account.Queries.Dto;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Mappings;
//using CleanArchitecture.Application.Common.Models;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Application.Account.Queries.GetToken
{
    //public class GetTokenQuery : IRequest<LoginDto>
    //{
    //    public string Username { get; set; }
    //    public string Pass { get; set; }
    //}

    //public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, LoginDto>
    //{
    //    private readonly SignInManager<IdentityUser> _signInManager;
    //    private readonly IMapper _mapper;

    //    public GetTokenQueryHandler(SignInManager<IdentityUser> signInManager, IMapper mapper)
    //    {
    //        _signInManager = signInManager;
    //        _mapper = mapper;
    //    }

    //    public async Task<LoginDto> Handle(GetTokenQuery request, CancellationToken cancellationToken)
    //    {
    //        var user = new IdentityUser(request.Username);
    //        var res = await _signInManager.CheckPasswordSignInAsync(user, request.Pass,false);
    //        if (res == SignInResult.Success)
    //        {
    //            var token = CreateToken(request.Username );
    //            return new LoginDto() { Token = token };
    //        }
    //        throw new Exception("something is wrong.");
    //    }
    //    private string CreateToken(string username)
    //    {
    //        List<Claim> claims = new List<Claim>
    //        {
    //            new Claim(ClaimTypes.Name, username)
    //        };
    //        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
    //            ""));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    //        DateTime d1 = DateTime.Now;
    //        DateTime d2 = d1.AddSeconds(60);

    //        var token = new JwtSecurityToken(
    //            claims: claims,
    //            expires: d2,
    //            signingCredentials: creds
    //            );
    //        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
    //        return jwt;
    //    }

    //}
}
