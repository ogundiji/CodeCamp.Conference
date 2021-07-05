using CodeCamp.Conference.Application.Features.Talks.Command.CreateTalk;
using CodeCamp.Conference.Application.Features.Talks.Command.DeleteTalk;
using CodeCamp.Conference.Application.Features.Talks.Command.UpdateTalk;
using CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalkByMoniker;
using CodeCamp.Conference.Application.Features.Talks.Query.GetSingleTalkByMoniker;
using CodeCamp.Conference.Application.Features.Talks.Query.GetTalkById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalkController : ControllerBase
    {
        private readonly IMediator mediator;
        public TalkController(IMediator mediator)
        {
           this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllTalk/{moniker}/{includeSpeaker}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string moniker,bool includeSpeaker)
        {
            return Ok(await mediator.Send(new GetAllTalkQuery() {moniker=moniker, includeSpeakers = includeSpeaker }));
        }

        [HttpGet]
        [Route("GetAllTalk/{talkId}/{moniker}/{includeSpeaker}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string moniker, bool includeSpeaker,Guid talkId)
        {
            return Ok(await mediator.Send(new GetSingleTalkQuery() { moniker = moniker, includeSpeaker = includeSpeaker, TalkId=talkId }));
        }

        [HttpGet]
        [Route("GetTalkById/{talkId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid talkId)
        {
            return Ok(await mediator.Send(new GetTalkQuery() { talkId = talkId }));
        }

        [HttpPost]
        [Route("CreateTalk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTalk([FromBody] CreateTalksCommand createTalkCommand)
        {
            return Ok(await mediator.Send(createTalkCommand));
        }

        [HttpPost]
        [Route("UpdateTalk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCamp([FromBody] UpdateTalkCommand updateTalkCommand)
        {
            return Ok(await mediator.Send(updateTalkCommand));
        }

        [HttpDelete]
        [Route("DeleteTalk/{talkId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCamp(Guid talkId)
        {
            return Ok(await mediator.Send(new DeleteTalkCommand() { TalkId = talkId }));
        }


    }
}
