﻿using CodeCamp.Conference.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Models.Authentication
{
    public class GetAllRoleResponse:BaseResponse
    {
        public List<RoleNameDto> data { get; set; }
        public GetAllRoleResponse():base()
        {

        }
    }
}
