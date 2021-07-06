using AutoMapper;
using CodeCamp.Conference.Application.Features.Camps.Command.CreateCamp;
using CodeCamp.Conference.Application.Features.Camps.Command.UpdateCamp;
using CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp;
using CodeCamp.Conference.Application.Features.Speakers.Commands.CreateSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Commands.UpdateSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Query.GetAllSpeaker;
using CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerById;
using CodeCamp.Conference.Application.Features.Talks.Command.CreateTalk;
using CodeCamp.Conference.Application.Features.Talks.Command.UpdateTalk;
using CodeCamp.Conference.Application.Features.Talks.Query.GetAllTalkByMoniker;
using CodeCamp.Conference.Domain.Entities;

namespace CodeCamp.Conference.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateSpeakerCommand,Speaker>();
            CreateMap<UpdateSpeakersCommand,Speaker>();
            CreateMap<Speaker, SpeakerDto>().ReverseMap();
            CreateMap<Speaker, GetSpeakerDto>().ReverseMap();



            CreateMap<CreateTalksCommand,Talk>();
            CreateMap<UpdateTalkCommand,Talk>();
            CreateMap<Talk, TalkDto>();

            CreateMap<CreateCampCommand,Camp>();
            CreateMap<UpdateCampCommand, Camp>();
            CreateMap<CampDto, Camp>();
        }
    }
}
