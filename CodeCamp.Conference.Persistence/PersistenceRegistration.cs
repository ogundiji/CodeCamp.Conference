using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CodeCampConferenceString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICampRepository, CampRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ITalkRepository, TalkRepository>();


            return services;
        }
    }
}
