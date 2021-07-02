﻿using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.CreateCamp
{
    public class CreateCampCommandHandler : IRequestHandler<CreateCampCommand, CreateCampCommandResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly ITalkRepository talkRepository;
        private readonly IMapper mapper;
        public CreateCampCommandHandler(ICampRepository campRepository, IMapper mapper, ITalkRepository talkRepository)
        {
            this.campRepository = campRepository;
            this.talkRepository = talkRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCampCommandResponse> Handle(CreateCampCommand request, CancellationToken cancellationToken)
        {
            var campResponse = new CreateCampCommandResponse();
            var campValidation = new CreateCampCommandValidator(campRepository);
            var campValidationResult = await campValidation.ValidateAsync(request);

            var talk = await talkRepository.GetByIdAsync(request.TalkId);


            if (talk == null)
            {
                campResponse.Success = false;
                throw new NotFoundException(nameof(Talk), request.TalkId);
            }

            if (campValidationResult.Errors.Count > 0)
            {
                campResponse.Success = false;
                campResponse.ValidationErrors = new List<string>();
                foreach (var error in campValidationResult.Errors)
                {
                    campResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (campResponse.Success)
            {
                request.talks = talk;
                var campToCreate= mapper.Map<Camp>(request);
                await campRepository.AddAsync(campToCreate);
            }

            return campResponse;
        }
    }
}