using CodeCamp.Conference.Application.Features.Camps.Command.CreateCamp;
using CodeCamp.Conference.Application.Features.Camps.Command.DeleteCamp;
using CodeCamp.Conference.Application.Features.Camps.Command.UpdateCamp;
using CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp;
using CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate;
using CodeCamp.Conference.Application.Features.Camps.Query.GetCampById;
using CodeCamp.Conference.Application.Features.Camps.Query.GetSingleCamp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class CampController : ControllerBase
    {
        private readonly IMediator mediator;
        public CampController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllCamps")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromHeader]bool includeSpeaker)
        {
            return Ok(await mediator.Send(new GetAllCampQuery() {includeSpeakers=includeSpeaker }));
        }

        [HttpGet]
        [Route("GetAllCampByEventDate/{eventDate}/{includeSpeakers}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCampByEventDate(DateTime eventDate,bool includeSpeakers )
        {
            return Ok(await mediator.Send(new GetAllCampByDateQuery() {dateTime=eventDate,includeSpeakers=includeSpeakers }));
        }

        [HttpGet]
        [Route("GetCampById/{campId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCampById(Guid campId)
        {
            return Ok(await mediator.Send(new GetCampQuery() { campId=campId }));
        }

        [HttpGet]
        [Route("GetCampByMoniker/{moniker}/{includeTalks}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCampByMoniker(string moniker,bool includeTalks)
        {
            return Ok(await mediator.Send(new GetSingleCampQuery() { moniker=moniker,includeTalks=includeTalks }));
        }


        [HttpPost]
        [Route("CreateCamp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCamp([FromBody] CreateCampCommand createCampCommand)
        {
            return Ok(await mediator.Send(createCampCommand));
        }

        [HttpPut]
        [Route("UpdateCamp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCamp([FromBody] UpdateCampCommand updateCampCommand)
        {
            return Ok(await mediator.Send(updateCampCommand));
        }

        [HttpDelete]
        [Route("DeleteCamp/{campId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCamp(Guid campId)
        {
            return Ok(await mediator.Send(new DeleteCampCommand() { campId = campId }));
        }

    }
}
