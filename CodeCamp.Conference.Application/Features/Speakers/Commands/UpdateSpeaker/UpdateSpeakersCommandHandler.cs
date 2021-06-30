using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Commands.UpdateSpeaker
{
    public class UpdateSpeakersCommandHandler : IRequestHandler<UpdateSpeakersCommand, UpdateSpeakersResponse>
    {
        private readonly ISpeakerRepository repository;
        private readonly IMapper mapper;
        public UpdateSpeakersCommandHandler(ISpeakerRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UpdateSpeakersResponse> Handle(UpdateSpeakersCommand request, CancellationToken cancellationToken)
        {
            var SpeakerToUpdate = await repository.GetByIdAsync(request.SpeakerId);

            if (SpeakerToUpdate == null)
            {
                throw new NotFoundException(nameof(Speaker), request.SpeakerId);
            }

            var validator = new UpdateSpeakersCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

             mapper.Map(request, SpeakerToUpdate, typeof(UpdateSpeakersCommand), typeof(Speaker));

            await repository.UpdateAsync(SpeakerToUpdate);

            return new UpdateSpeakersResponse();
        }
    }
}
