using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PersonManager.Application.Account.Queries.GetIsAdmin;
using PersonManager.Application.Account.Queries.Dto;
using PersonManager.Domain.Models;

namespace PersonManager.WebUI.Controllers
{
    public class Test2Controller : ApiControllerBase
    {
        [HttpGet("/Test2/PublicAction")]
        public async Task<ActionResult> GetPublic()
        {
            return Ok();
        }
        [Authorize]
        [HttpGet("/Test2/PrivateAction")]
        public async Task<ActionResult> GetPrivate()
        {
            return Ok();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("/Test2/AdminAction")]
        public async Task<ActionResult> GetAdmin()
        {
            return Ok();
            //return await Mediator.Send(new GetIsAdminQuery());
        }
    }
}
