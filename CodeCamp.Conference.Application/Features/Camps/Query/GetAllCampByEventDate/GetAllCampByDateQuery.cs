﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCampByEventDate
{
    public class GetAllCampByDateQuery:IRequest<CampDto[]>
    {
        public DateTime dateTime { get; set; }
        public bool includeSpeakers { get; set; }
    }
}