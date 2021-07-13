using CodeCamp.Conference.Application.Contracts.Infrastructure;
using CodeCamp.Conference.Application.Models.Mail;
using CodeCamp.Conference.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            service.AddTransient<IEmailService, EmailService>();

            return service;
        }
    }
}
