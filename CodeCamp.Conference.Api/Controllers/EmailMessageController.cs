using CodeCamp.Conference.Api.Models;
using CodeCamp.Conference.Application.Contracts.Infrastructure;
using CodeCamp.Conference.Application.Models.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailMessageController : ControllerBase
    {
        private readonly IEmailService service;
        public EmailMessageController(IEmailService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail([FromBody] Email email)
        {
            return Ok(service.SendEmail(email));
        }
    }
}
