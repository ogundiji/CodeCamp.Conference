using CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Commands.DeleteSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Commands.UpdateSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Query.GetAllSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerById;
using CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerByMoniker;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly IMediator mediator;
        public SpeakerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllSpeakers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAllSpeakerQuery()));
        }

        [HttpGet]
        [Route("GetSpeakerByMoniker")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string moniker)
        {
            return Ok(await mediator.Send(new GetAllSpeakerByMonikerQuery() { Moniker = moniker }));
        }

        [HttpGet]
        [Route("GetSpeakerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromHeader] Guid SpeakerId)
        {
            return Ok(await mediator.Send(new GetSpeakerQuery() { SpeakerId = SpeakerId }));
        }


        [HttpPost]
        [Route("CreateSpeaker")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSpeaker([FromBody] CreateSpeakerCommand createSpeakerCommand)
        {
            return Ok(await mediator.Send(createSpeakerCommand));
        }


        [HttpPut]
        [Route("UpdateSpeaker")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSpeaker([FromBody] UpdateSpeakersCommand updateSpeakerCommand)
        {
            return Ok(await mediator.Send(updateSpeakerCommand));
        }

        [HttpDelete]
        [Route("DeleteSpeaker")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSpeaker([FromHeader] Guid speakerId)
        {
            return Ok(await mediator.Send(new DeleteSpeakerCommand() { SpeakerId=speakerId }));
        }

    }
}
