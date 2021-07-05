﻿using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Query.GetAllCamp
{
    public class CampResponse:BaseResponse
    {
        public CampDto[] data { get; set; }
        public CampResponse():base()
        {

        }
    }
}
