﻿using CodeCamp.Conference.Application.Response;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class CampResponse:BaseResponse
    {
        public CampByEventDto[] data { get; set; }
        public CampResponse()
        {

        }
    }
}
