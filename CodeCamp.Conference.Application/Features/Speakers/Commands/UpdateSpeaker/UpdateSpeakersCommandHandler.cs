using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker;
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
        public Task<UpdateSpeakersResponse> Handle(UpdateSpeakersCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
