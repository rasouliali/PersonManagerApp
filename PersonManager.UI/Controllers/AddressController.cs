using PersonManager.Application.Addresses.Commands.CreateAddress;
using PersonManager.Application.Addresses.Commands.DeleteAddress;
using PersonManager.Application.Addresses.Commands.UpdateAddress;
using PersonManager.Application.Addresses.Queries.GetAddresses;
using PersonManager.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManager.WebUI.Controllers
{
    [Authorize]
    public class AddressesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<AddressDto>> Get()
        {
            return await Mediator.Send(new GetAddressesQuery());
        }

        [HttpGet("{id}")]
        public async Task<AddressDto> Get(int id)
        {

            return await Mediator.Send(new GetAddressByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAddressCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAddressCommand { Id = id });

            return NoContent();
        }
    }
}
