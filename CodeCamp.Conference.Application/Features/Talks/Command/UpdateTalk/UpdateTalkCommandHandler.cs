using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Application.Features.Speakers.Commands.UpdateSpeaker;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.UpdateTalk
{
    public class UpdateTalkCommandHandler : IRequestHandler<UpdateTalkCommand, UpdateTalkResponse>
    {
        private readonly ITalkRepository talkRepository;
        private readonly ISpeakerRepository speakerRepository;
        private readonly IMapper mapper;
        public UpdateTalkCommandHandler(ITalkRepository talkRepository, IMapper mapper, ISpeakerRepository speakerRepository)
        {
            this.talkRepository = talkRepository;
            this.mapper = mapper;
            this.speakerRepository = speakerRepository;
        }

        public  async Task<UpdateTalkResponse> Handle(UpdateTalkCommand request, CancellationToken cancellationToken)
        {
            var TalkToUpdate = await talkRepository.GetByIdAsync(request.TalkId);
            var SpeakerToUpdate = await speakerRepository.GetByIdAsync(request.SpeakerId);
            var talkResponse = new UpdateTalkResponse();

            if (SpeakerToUpdate == null)
            {
                talkResponse.Success = false;
                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }

            if (TalkToUpdate == null)
            {
                talkResponse.Success = false;
                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }



            var validator = new UpdateTalkCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
            {
                talkResponse.Success = false;
                talkResponse.Message = "Record Not Found";
                talkResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    talkResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(validationResult);
            }

            if (talkResponse.Success)
            {
                talkResponse.statusCode = 200;
                talkResponse.Message = "successfully updated record";
                mapper.Map(request, TalkToUpdate, typeof(UpdateTalkCommand), typeof(Talk));
                TalkToUpdate.Speaker = SpeakerToUpdate;
                await talkRepository.UpdateAsync(TalkToUpdate);
            }

            return talkResponse;
        }
    }
}
