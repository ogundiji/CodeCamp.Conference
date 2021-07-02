﻿using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Talks.Command.DeleteTalk
{
    public class DeleteTalksCommandHandler : IRequestHandler<DeleteTalkCommand, DeleteTalkCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ITalkRepository talkRepository;
        public DeleteTalksCommandHandler(ITalkRepository talkRepository)
        {
            this.talkRepository = talkRepository;
        }
        public async Task<DeleteTalkCommandResponse> Handle(DeleteTalkCommand request, CancellationToken cancellationToken)
        {
            var talkToDelete = await talkRepository.GetByIdAsync(request.TalkId);
            var talkDeleteResponse = new DeleteTalkCommandResponse();

            if (talkToDelete == null)
            {
                talkDeleteResponse.Success = false;
                throw new NotFoundException(nameof(Talks), request.TalkId);
            }

            if (talkDeleteResponse.Success)
            {
                await talkRepository.DeleteAsync(talkToDelete);
            }

            return talkDeleteResponse;
        }
    }
}