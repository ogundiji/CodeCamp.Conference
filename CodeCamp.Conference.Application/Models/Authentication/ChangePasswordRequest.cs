﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Models.Authentication
{
    public class ChangePasswordRequest
    {
        public string userId { get; set; }
        public string password { get; set; }
    }
}
