﻿using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Speakers.Query.GetSpeakerById
{
    public class SpeakerResponse:BaseResponse
    {
        public GetSpeakerDto data { get; set; }
        public SpeakerResponse():base()
        {
        }
    }
}
