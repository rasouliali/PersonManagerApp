using PersonManager.Application.Common.Models;
using PersonManager.Application.Persons.Commands.CreatePerson;
using PersonManager.Application.Persons.Commands.DeletePerson;
using PersonManager.Application.Persons.Commands.UpdatePerson;
using PersonManager.Application.Persons.Commands.UpdatePersonDetail;
using PersonManager.Application.Persons.Queries.GetPersonsWithPagination;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PersonManager.WebUI.Controllers
{
    [Authorize]
    public class PersonsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<PersonBriefDto>>> GetPersonsWithPagination([FromQuery] GetPersonsWithPaginationQuery query)
        {
            //new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())
            var data = new Secret("".Sha256());
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdatePersonDetailCommand command)
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
            await Mediator.Send(new DeletePersonCommand { Id = id });

            return NoContent();
        }
    }
}
